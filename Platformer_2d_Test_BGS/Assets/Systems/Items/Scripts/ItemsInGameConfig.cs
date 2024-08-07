using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsInGame", menuName = "Items/ItemsInGame")]
public class ItemsInGameConfig : ScriptableObject
{
    #region EXPOSED_FIELDS
    [SerializeField] private List<ItemConfig> itemsInGame = null;
    #endregion

    #region PROPERTIES
    public List<ItemConfig> ItemsInGame { get => itemsInGame; }
    #endregion

    #region PUBLIC_METHODS
    public ItemConfig GetItemByName(string name)
    {
        for (int i = 0; i < itemsInGame.Count; i++)
        {
            if (itemsInGame[i].ItemName == name)
            {
                return itemsInGame[i];
            }
        }

        return null;
    }
    #endregion
}