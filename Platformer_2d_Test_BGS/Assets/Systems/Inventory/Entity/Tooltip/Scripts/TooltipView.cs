using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class TooltipView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Image iconPreview = null;
    [SerializeField] private TextMeshProUGUI nameText = null;
    [SerializeField] private TextMeshProUGUI descriptionText = null;
    #endregion

    #region PUBLIC_METHODS
    public void SetTooltipData(Sprite image, string name, string description)
    {
        iconPreview.sprite = image;
        nameText.text = name;
        descriptionText.text = description;
    }
    #endregion
}
