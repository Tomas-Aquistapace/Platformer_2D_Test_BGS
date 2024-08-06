using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Image icon = null;

    #endregion

    #region PRIVATE_FIELDS
    
    #endregion

    #region PUBLIC_METHODS
    public void SetIconSprite(Sprite image)
    {
        icon.sprite = image;
    }
    #endregion

    #region PRIVATE_METHODS

    #endregion
}
