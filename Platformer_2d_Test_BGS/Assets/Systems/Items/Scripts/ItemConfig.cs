using UnityEngine;

[CreateAssetMenu(fileName = "StandardItem", menuName = "Items/StandardItem")]
public class ItemConfig : ScriptableObject
{
    #region EXPOSED_FIELDS
    [SerializeField] private Sprite icon = null;
    [SerializeField] private string itemName = string.Empty;
    [SerializeField] private string itemDescription = string.Empty;
    #endregion

    #region PROPERTIES
    public Sprite Icon { get => icon; }
    public string ItemName { get => itemName; }
    public string ItemDescription { get => itemDescription; }
    #endregion
}