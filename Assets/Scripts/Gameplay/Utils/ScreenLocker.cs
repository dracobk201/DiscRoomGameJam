using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLocker : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.Locked == Cursor.lockState ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
