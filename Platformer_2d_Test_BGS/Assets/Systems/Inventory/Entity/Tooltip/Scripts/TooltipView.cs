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
    public void SetData(Sprite image, string name, string description)
    {
        iconPreview.sprite = image;
        nameText.text = name;
        descriptionText.text = description;

        iconPreview.enabled = true;
    }

    public void CleanData()
    {
        iconPreview.enabled = false;

        iconPreview.sprite = null;
        nameText.text = string.Empty;
        descriptionText.text = string.Empty;
    }
    #endregion
}
