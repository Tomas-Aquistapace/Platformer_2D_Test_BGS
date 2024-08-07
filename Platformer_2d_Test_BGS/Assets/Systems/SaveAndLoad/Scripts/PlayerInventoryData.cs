using System.Collections.Generic;

public class PlayerInventoryData
{
    #region PRIVATE_FIELDS
    private List<ItemConfig> inventoryItems = null;
    private ItemConfig leftHand = null;
    private ItemConfig rightHand = null;
    #endregion

    #region PROPERTIES
    public List<ItemConfig> InventoryItems { get => inventoryItems; set => inventoryItems = value; }
    public ItemConfig LeftHand { get => leftHand; set => leftHand = value; }
    public ItemConfig RightHand { get => rightHand; set => rightHand = value; }
    #endregion
}
