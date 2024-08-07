using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StandardItem", menuName = "Items/StandardItem")]
public class ItemConfig : ScriptableObject
{
    public enum ItemType
    {
        Collectable,
        Consumable,
        Equipable
    }

    #region EXPOSED_FIELDS
    [SerializeField] private Sprite icon = null;
    [SerializeField] private ItemType type = ItemType.Collectable;
    [SerializeField] private string itemName = string.Empty;
    [SerializeField] private string itemDescription = string.Empty;
    #endregion

    #region PROPERTIES
    public Sprite Icon { get => icon; }
    public ItemType Type { get => type; }
    public string ItemName { get => itemName; }
    public string ItemDescription { get => itemDescription; }
    #endregion
}