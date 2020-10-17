using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2Reference mouseAxis = null;
    [SerializeField] private FloatReference minCameraRotation = null;
    [SerializeField] private FloatReference maxCameraRotation = null;
    [SerializeField] private FloatReference horizontalCameraSensitivity = null;
    [SerializeField] private FloatReference verticalCameraSensitivity = null;
    [SerializeField] private Camera playerCamera = null;
    private Rigidbody _playerRigidbody;
    private float rotAroundX, rotAroundY;

    private void Start()
    {
        _playerRigidbody = (TryGetComponent(out Rigidbody rigidbodyResult)) ? rigidbodyResult : gameObject.AddComponent<Rigidbody>();
        rotAroundX = transform.eulerAngles.x;
        rotAroundY = transform.eulerAngles.y;
    }

    public void RotateCamera()
    {
        rotAroundX += mouseAxis.Value.x * horizontalCameraSensitivity.Value * Time.deltaTime;
        rotAroundY += mouseAxis.Value.y * verticalCameraSensitivity.Value * Time.deltaTime;

        rotAroundX = Mathf.Clamp(rotAroundX, minCameraRotation.Value, maxCameraRotation.Value);
        CameraRotation();
    }

    private void CameraRotation()
    {
        _playerRigidbody.rotation = Quaternion.Euler(0, rotAroundY, 0);
        playerCamera.transform.rotation = Quaternion.Euler(-rotAroundX, rotAroundY, 0);
    }
}