using UnityEngine;
using UnityEngine.UI;

public class DragDropItemView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Image image = null;
    #endregion

    #region PRIVATE_FIELDS
    private bool isEnable = false;
    #endregion

    #region PROPERTIES
    public bool IsEnable { get => isEnable; }
    #endregion

    #region PUBLIC_METHODS
    public void UpdateImage()
    {
        if(!isEnable)
        {
            return;
        }

        image.transform.position = Input.mousePosition;
    }

    public void SetImage(Sprite sprite)
    {
        isEnable = true;

        image.sprite = sprite;
        image.transform.position = Input.mousePosition;

        image.enabled = true;
    }

    public void ClearImage()
    {
        isEnable = false;

        image.enabled = false;
        image.sprite = null;
    }
    #endregion
}