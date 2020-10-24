using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiationPoint : MonoBehaviour
{
    public PropType propType;
    public bool used = false;

    public void AddObject(PropSO prop)
    {
        var instance = Instantiate(prop.prefab, transform.position, transform.rotation, transform);
        instance.transform.position = instance.transform.position
        + Random.Range(-prop.positionRange.x, prop.positionRange.x) * Vector3.right
        + Random.Range(-prop.positionRange.y, prop.positionRange.y) * Vector3.up
        + Random.Range(-prop.positionRange.z, prop.positionRange.z) * Vector3.forward;
        instance.transform.localScale = instance.transform.localScale + Random.Range(-prop.scaleRange, prop.scaleRange) * Vector3.one;
        Vector3 currentRotation = instance.transform.rotation.eulerAngles;
        currentRotation.y = currentRotation.y + Random.Range(-prop.rotationRange, prop.rotationRange);
        instance.transform.rotation = Quaternion.Euler(currentRotation);
    }

    public void Clean()
    {
        used = false;
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
