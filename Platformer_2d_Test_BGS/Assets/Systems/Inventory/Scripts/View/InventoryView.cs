using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Transform slotsParent = null;
    [SerializeField] private GameObject slotViewPrefab = null;
    #endregion

    #region PUBLIC_METHODS
    public InventorySlotView InstantiateItemView()
    {
        InventorySlotView itemView = Instantiate(slotViewPrefab, slotsParent).GetComponent<InventorySlotView>();
        return itemView;
    }
    #endregion
}