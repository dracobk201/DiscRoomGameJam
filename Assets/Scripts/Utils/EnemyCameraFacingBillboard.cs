using UnityEngine;
 
public class EnemyCameraFacingBillboard : MonoBehaviour
{
    private Camera _camera;
 
    private void Start()
    {
        _camera = Camera.main;
        if (_camera == null)
            Debug.LogError("Main camera not found!!!");
    }

    private void Update()
    {
        if (_camera != null)
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}