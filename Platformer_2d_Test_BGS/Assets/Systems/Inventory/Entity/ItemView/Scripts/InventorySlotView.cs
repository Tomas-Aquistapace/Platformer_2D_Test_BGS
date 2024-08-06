using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Image icon = null;
    #endregion

    #region PRIVATE_FIELDS
    private ItemConfig itemConfig = null;
    #endregion

    #region PROPERTIES
    public bool HasItem { get => itemConfig != null; }
    public ItemConfig ItemConfig { get => itemConfig; }
    #endregion

    #region PUBLIC_METHODS
    public void SetItem(ItemConfig itemConfig)
    {
        if(itemConfig == null)
        {
            return;
        }

        this.itemConfig = itemConfig;
        icon.sprite = itemConfig.Icon;
        icon.enabled = true;
    }

    public void RemoveItem()
    {
        itemConfig = null;
        icon.enabled = false;
    }
    #endregion

    #region PRIVATE_METHODS

    #endregion
}
