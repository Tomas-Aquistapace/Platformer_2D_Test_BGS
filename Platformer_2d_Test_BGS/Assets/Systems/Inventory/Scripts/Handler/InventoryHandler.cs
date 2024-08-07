using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region EXPOSED_FIELDS
    [SerializeField] private EquippedItemsView equippedItemsView = null;
    [SerializeField] private TooltipView tooltipView = null;
    [SerializeField] private DragDropItemView dragDropItemView = null;
    [Space]
    [SerializeField] private List<InventorySlotView> itemSlotViews = null;
    [Space]
    [SerializeField] private GameObject inventoryHolder = null;
    [SerializeField] private Button saveInventoryButton = null;

    [Header("Input Values")]
    [SerializeField] private float pressDetection = 0.3f;
    [SerializeField] private int inventoryAmount = 20;

    [Header("Audio Values")]
    [SerializeField] private AudioSource audioSource = null;
    #endregion

    #region PRIVATE_FIELDS
    private ItemData heldItem = null;
    private InventorySlotView heldSlot = null;

    private bool onPointerUp = false;
    private float pointerTime = 0;

    private Action onPlayerStop = null;
    #endregion

    #region UNITY_METHODS
    private void Update()
    {
        dragDropItemView.UpdateImage();
        InputInteraction();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerUp = false;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            InventorySlotView slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<InventorySlotView>();

            if(slot != null && slot.HasItem)
            {
                heldSlot = slot;
                heldItem = slot.ItemData;
                StartCoroutine(TimerController());
            }
            else
            {
                tooltipView.CleanData();
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp = true;

        if(heldItem == null || heldSlot == null || eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }

        if(pointerTime < pressDetection)
        {
            tooltipView.SetData(heldSlot);
            heldItem = null;

            audioSource.Play();
        }
        else
        {
            if (eventData.pointerCurrentRaycast.gameObject == null)
            {
                heldSlot = null;
                heldItem = null;
            }
            else
            {
                InventorySlotView selectedSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<InventorySlotView>();

                if (selectedSlot != null)
                {
                    if (selectedSlot.CanContainItem(heldItem.Type))
                    {
                        heldSlot.RemoveItem();
                        heldSlot.SetItem(selectedSlot.ItemData);
                        heldSlot = null;

                        selectedSlot.SetItem(heldItem);
                        heldItem = null;
                    }
                    else
                    {
                        heldSlot = null;
                        heldItem = null;
                    }
                }
            }

            dragDropItemView.ClearImage();

            audioSource.Play();
        }
    }
    #endregion

    #region PUBLIC_METHODS
    public void Initialize(ItemsInGameConfig itemsInGameConfig, PlayerInventoryData data, Action onPlayerStop)
    {
        if (data != null)
        {
            for (int i = 0; i < data.InventoryItems.Count; i++)
            {
                ItemConfig config = itemsInGameConfig.GetItemByName(data.InventoryItems[i]);

                if (config != null)
                {
                    ItemData itemData = new ItemData(config.Icon, config.Type, config.ItemName, config.ItemDescription);
                    itemSlotViews[i].SetItem(itemData);
                }
            }
            ItemConfig leftItem = itemsInGameConfig.GetItemByName(data.LeftHand);
            ItemData leftData = null;
            if (leftItem != null)
            {
                leftData = new ItemData(leftItem.Icon, leftItem.Type, leftItem.ItemName, leftItem.ItemDescription);
            }
            
            ItemConfig rightItem = itemsInGameConfig.GetItemByName(data.RightHand);
            ItemData rightData = null;
            if (rightItem != null)
            {
                rightData = new ItemData(rightItem.Icon, rightItem.Type, rightItem.ItemName, rightItem.ItemDescription);
            }

            equippedItemsView.SetUpInitialItems(leftData, rightData);
        }

        this.onPlayerStop = onPlayerStop;

        tooltipView.Configure(UseItem);

        saveInventoryButton.onClick.AddListener(() =>
        {
            SaveInventory();
        });
    }

    public bool AddItemInInventory(ItemData newItem)
    {
        for (int i = 0; i < itemSlotViews.Count; i++)
        {
            if (!itemSlotViews[i].HasItem)
            {
                itemSlotViews[i].SetItem(newItem);
                return true;
            }
        }

        return false;
    }
    #endregion

    #region PRIVATE_METHODS
    private void SaveInventory()
    {
        PlayerInventoryData data = new PlayerInventoryData();
        data.InventoryItems = new List<string>();

        for (int i = 0; i < itemSlotViews.Count; i++)
        {
            if(itemSlotViews[i].ItemData != null)
            {
                data.InventoryItems.Add(itemSlotViews[i].ItemData.ItemName);
            }
            else
            {
                data.InventoryItems.Add(string.Empty);
            }
        }

        if(equippedItemsView.LeftInventorySlot.ItemData != null)
        {
            data.LeftHand = equippedItemsView.LeftInventorySlot.ItemData.ItemName;
        }

        if(equippedItemsView.RightInventorySlot.ItemData != null)
        {
            data.RightHand = equippedItemsView.RightInventorySlot.ItemData.ItemName;
        }

        SaveSystem.SaveInventory(data);
    }

    private void InputInteraction()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            onPlayerStop.Invoke();
            inventoryHolder.SetActive(!inventoryHolder.activeSelf);
        }
    }

    private void UseItem(InventorySlotView inventorySlotView)
    {
        inventorySlotView.RemoveItem();
    }

    private IEnumerator TimerController()
    {
        pointerTime = 0;

        while (onPointerUp == false)
        {
            pointerTime += Time.deltaTime;

            if(pointerTime >= pressDetection && !dragDropItemView.IsEnable)
            {
                dragDropItemView.SetImage(heldItem.Icon);
            }

            yield return null;
        }
    }
    #endregion
}