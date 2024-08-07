using UnityEngine;

public class ItemInteractableView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private ItemConfig itemConfig = null;
    #endregion

    #region UNITY_METHODS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            ItemData itemData = new ItemData(itemConfig.Icon, itemConfig.Type, itemConfig.ItemName, itemConfig.ItemDescription);

            collision.gameObject.GetComponent<PlayerController>().OnAddItemInInventory(itemData);
            Destroy(gameObject);
        }        
    }
    #endregion
}
