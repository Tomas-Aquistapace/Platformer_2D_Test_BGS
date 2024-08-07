using System;
using UnityEngine;
using static ItemConfig;

[Serializable]
public class ItemData
{
    #region EXPOSED_FIELDS
    private Sprite icon = null;
    private ItemType type = ItemType.Collectable;
    private string itemName = string.Empty;
    private string itemDescription = string.Empty;
    #endregion

    #region PROPERTIES
    public Sprite Icon { get => icon; }
    public ItemType Type { get => type; }
    public string ItemName { get => itemName; }
    public string ItemDescription { get => itemDescription; }
    #endregion

    #region CONSTRUCTOR
    public ItemData(Sprite icon, ItemType type, string itemName, string itemDescription)
    {
        this.icon = icon;
        this.type = type;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
    }
    #endregion
}
