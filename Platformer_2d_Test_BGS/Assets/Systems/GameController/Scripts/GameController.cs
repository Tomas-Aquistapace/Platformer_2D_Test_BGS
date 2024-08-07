using UnityEngine;

public class GameController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private InventoryHandler inventoryHandler = null;
    [SerializeField] private PlayerController playerController = null;
    [Space]
    [SerializeField] private ItemsInGameConfig itemsInGameConfig = null;
    #endregion

    #region PRIVATE_FIELDS

    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        Initialize();
    }
    #endregion

    #region PRIVATE_METHODS
    private void Initialize()
    {
        PlayerInventoryData inventoryData = SaveSystem.LoadInventory();

        playerController.Initialize(inventoryHandler.AddItemInInventory);
        inventoryHandler.Initialize(itemsInGameConfig, inventoryData, playerController.EnableMovement);
    }
    #endregion
}