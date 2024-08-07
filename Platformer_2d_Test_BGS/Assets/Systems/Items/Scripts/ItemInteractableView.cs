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
            collision.gameObject.GetComponent<PlayerController>().OnAddItemInInventory(itemConfig);
            Destroy(gameObject);
        }        
    }
    #endregion
}
