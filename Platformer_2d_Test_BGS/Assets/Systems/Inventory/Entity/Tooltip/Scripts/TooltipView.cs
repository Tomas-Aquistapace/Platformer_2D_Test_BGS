using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;

public class TooltipView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Image iconPreview = null;
    [SerializeField] private TextMeshProUGUI nameText = null;
    [SerializeField] private TextMeshProUGUI typeText = null;
    [SerializeField] private TextMeshProUGUI descriptionText = null;
    [Space]
    [SerializeField] private Button useItemButton = null;
    [SerializeField] private Button removeItemButton = null;
    #endregion

    #region PRIVATE_FIELDS
    private InventorySlotView heldSlot = null;
    #endregion

    #region PUBLIC_METHODS
    public void Configure(Action<InventorySlotView> onUseItem)
    {
        useItemButton.onClick.AddListener(() =>
        {
            onUseItem.Invoke(heldSlot);
            CleanData();
        });

        removeItemButton.onClick.AddListener(() =>
        {
            CleanData();
        });
    }

    public void SetData(InventorySlotView inventorySlotView)
    {
        heldSlot = inventorySlotView;

        iconPreview.sprite = heldSlot.ItemData.Icon;
        nameText.text = heldSlot.ItemData.ItemName;
        typeText.text = heldSlot.ItemData.Type.ToString();
        descriptionText.text = heldSlot.ItemData.ItemDescription;

        useItemButton.gameObject.SetActive(heldSlot.ItemData.Type == ItemConfig.ItemType.Consumable);

        iconPreview.enabled = true;
    }

    public void CleanData()
    {
        heldSlot = null;
        iconPreview.enabled = false;

        iconPreview.sprite = null;
        nameText.text = string.Empty;
        typeText.text = string.Empty;
        descriptionText.text = string.Empty;

        useItemButton.gameObject.SetActive(false);
    }
    #endregion
}
