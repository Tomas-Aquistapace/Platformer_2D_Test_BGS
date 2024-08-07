using UnityEngine;

public class EquippedItemsView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private InventorySlotView leftInventorySlot = null;
    [SerializeField] private InventorySlotView rightInventorySlot = null;
    #endregion

    #region PROPERTIES
    public InventorySlotView LeftInventorySlot { get => leftInventorySlot; }
    public InventorySlotView RightInventorySlot { get => rightInventorySlot; }
    #endregion

    #region PUBLIC_METHODS
    public void SetUpInitialItems(ItemData left, ItemData right)
    {
        leftInventorySlot.SetItem(left);
        rightInventorySlot.SetItem(right);
    }
    #endregion
}
