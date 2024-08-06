using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private TooltipView tooltipView = null;
    [Space]
    [SerializeField] private Transform itemsParent = null;
    [SerializeField] private GameObject itemViewPrefab = null;
    #endregion

    #region PUBLIC_METHODS
    public ItemView InstantiateItemView()
    {
        ItemView itemView = Instantiate(itemViewPrefab, itemsParent).GetComponent<ItemView>();
        return itemView;
    }

    public void SetTooltipData(Sprite image, string name, string description)
    {
        tooltipView.SetTooltipData(image, name, description);
    }
    #endregion
}