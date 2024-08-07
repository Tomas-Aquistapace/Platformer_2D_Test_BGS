using UnityEngine;

public class GameController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private InventoryHandler inventoryHandler = null;
    [SerializeField] private PlayerController playerController = null;
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
        PlayerInventoryData inventoryData = new PlayerInventoryData();

        inventoryHandler.Initialize(inventoryData, playerController.EnableMovement);
    }
    #endregion
}