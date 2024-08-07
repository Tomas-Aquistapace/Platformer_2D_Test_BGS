using System;
using System.Collections.Generic;

[Serializable]
public class PlayerInventoryData
{
    #region PRIVATE_FIELDS
    private List<string> inventoryItems = new List<string>();
    private string leftHand = string.Empty;
    private string rightHand = string.Empty;
    #endregion

    #region PROPERTIES
    public List<string> InventoryItems { get => inventoryItems; set => inventoryItems = value; }
    public string LeftHand { get => leftHand; set => leftHand = value; }
    public string RightHand { get => rightHand; set => rightHand = value; }
    #endregion
}
