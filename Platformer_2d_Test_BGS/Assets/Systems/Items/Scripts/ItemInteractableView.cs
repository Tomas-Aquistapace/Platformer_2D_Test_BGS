using UnityEngine;

public class ItemInteractableView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Animator animator = null;
    [SerializeField] private ItemConfig itemConfig = null;
    #endregion

    #region CONSTANTS
    private const string destroyTrigger = "Destroy";
    #endregion

    #region UNITY_METHODS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            ItemData itemData = new ItemData(itemConfig.Icon, itemConfig.Type, itemConfig.ItemName, itemConfig.ItemDescription);

            if (collision.gameObject.GetComponent<PlayerController>().OnAddItemInInventory(itemData))
            {
                animator.SetTrigger(destroyTrigger);
            }
        }        
    }
    #endregion

    #region ANIMATION_METHODS
    private void OnDestroyItem()
    {
        Destroy(gameObject);
    }
    #endregion
}
