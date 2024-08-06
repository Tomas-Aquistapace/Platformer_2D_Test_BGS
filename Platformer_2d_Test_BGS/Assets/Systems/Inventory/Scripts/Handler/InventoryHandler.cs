using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private InventoryView inventoryView = null;

    [Header("TEST DATA")]
    [SerializeField] private int inventoryAmount = 10;
    #endregion

    #region PRIVATE_FIELDS
    private List<ItemView> itemViews = null;
    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        itemViews = new List<ItemView>();

        for (int i = 0; i < inventoryAmount; i++)
        {
            itemViews.Add(inventoryView.InstantiateItemView());
        }
    }
    #endregion

    #region PUBLIC_METHODS

    #endregion

    #region PRIVATE_METHODS

    #endregion
}