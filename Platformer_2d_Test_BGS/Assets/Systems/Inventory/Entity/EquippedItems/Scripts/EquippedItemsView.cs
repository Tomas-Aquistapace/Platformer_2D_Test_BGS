using UnityEngine;

public class EquippedItemsView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private InventorySlotView leftInventorySlot = null;
    [SerializeField] private InventorySlotView rightInventorySlot = null;
    #endregion

    #region PRIVATE_FIELDS

    #endregion

    #region PUBLIC_METHODS
    public void SetUpInitialItems(ItemConfig left, ItemConfig right)
    {
        leftInventorySlot.SetItem(left);
        rightInventorySlot.SetItem(right);
    }
    #endregion
}
