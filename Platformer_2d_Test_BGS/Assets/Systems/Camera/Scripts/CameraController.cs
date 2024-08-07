using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private GameObject target = null;
    [Space]
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -5);
    [SerializeField] private float smoothTime = 0.25f;
    #endregion

    #region PRIVATE_FIELDS
    private Vector3 currentVel = Vector3.zero;
    #endregion

    #region UNITY_METHODS
    private void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVel, smoothTime);
    }
    #endregion
}
