using UnityEngine;
 
public class IconCameraFacingBillboard : MonoBehaviour
{
    private Camera _camera;
 
    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag(Global.CameraMinimapTag).GetComponent<Camera>();
        if (_camera == null)
            Debug.LogError("Minimap camera not found!!!");
    }

    private void LateUpdate()
    {
        if (_camera != null)
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}