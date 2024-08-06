using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region EXPOSED_FIELDS
    [SerializeField] private InventoryView inventoryView = null;
    [SerializeField] private TooltipView tooltipView = null;
    [SerializeField] private DragDropItemView dragDropItemView = null;

    [Header("TEST DATA")]
    [SerializeField] private ItemConfig testItemConfig = null;
    [SerializeField] private ItemConfig testItemCupConfig = null;
    [Space]
    [SerializeField] private float pressDetection = 0.3f;
    [SerializeField] private int inventoryAmount = 20;
    #endregion

    #region PRIVATE_FIELDS
    private List<InventorySlotView> itemViews = null;

    private ItemConfig heldItem = null;
    private InventorySlotView heldSlot = null;

    private bool onPointerUp = false;
    private float pointerTime = 0;
    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        itemViews = new List<InventorySlotView>();

        for (int i = 0; i < inventoryAmount; i++)
        {
            itemViews.Add(inventoryView.InstantiateItemView());
        }

        itemViews[2].SetItem(testItemConfig);
        itemViews[4].SetItem(testItemConfig);
        itemViews[10].SetItem(testItemCupConfig);
    }

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

        if(heldItem == null || eventData.button != PointerEventData.InputButton.Left)
        {
            return;
        }

        if(pointerTime < pressDetection)
        {
            tooltipView.SetData(heldItem.Icon, heldItem.ItemName, heldItem.ItemDescription);
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
                InventorySlotView slot = eventData.pointerCurrentRaycast.gameObject.GetComponent<InventorySlotView>();

                if (slot != null)
                {
                    heldSlot.RemoveItem();
                    heldSlot.SetItem(slot.ItemConfig);
                    heldSlot = null;

                    slot.SetItem(heldItem);
                    heldItem = null;
                }
            }

            dragDropItemView.ClearImage();
        }
    }
    #endregion

    #region PUBLIC_METHODS

    #endregion

    #region PRIVATE_METHODS
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