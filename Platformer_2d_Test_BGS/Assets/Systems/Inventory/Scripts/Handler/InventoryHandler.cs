using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region EXPOSED_FIELDS
    [SerializeField] private EquippedItemsView equippedItemsView = null;
    [SerializeField] private TooltipView tooltipView = null;
    [SerializeField] private DragDropItemView dragDropItemView = null;
    [Space]
    [SerializeField] private List<InventorySlotView> itemSlotViews = null;

    [Header("Input Values")]
    [SerializeField] private float pressDetection = 0.3f;
    [SerializeField] private int inventoryAmount = 20;
    #endregion

    #region PRIVATE_FIELDS
    private ItemConfig heldItem = null;
    private InventorySlotView heldSlot = null;

    private bool onPointerUp = false;
    private float pointerTime = 0;
    #endregion

    #region UNITY_METHODS
    private void Update()
    {
        dragDropItemView.UpdateImage();
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
                heldItem = slot.ItemConfig;
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
                        heldSlot.SetItem(selectedSlot.ItemConfig);
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
        }
    }
    #endregion

    #region PUBLIC_METHODS
    public void Initialize(PlayerInventoryData data)
    {
        for (int i = 0; i < data.InventoryItems.Count; i++)
        {
            itemSlotViews[i].SetItem(data.InventoryItems[i]);
        }

        equippedItemsView.SetUpInitialItems(data.LeftHand, data.RightHand);
        tooltipView.Configure(UseItem);
    }
    #endregion

    #region PRIVATE_METHODS
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