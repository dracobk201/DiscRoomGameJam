using UnityEngine;
 
public class CameraFacingBillboard : MonoBehaviour
{
    private Camera _camera;
 
    private void Start(){
        _camera = FindObjectOfType<Camera>();
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}