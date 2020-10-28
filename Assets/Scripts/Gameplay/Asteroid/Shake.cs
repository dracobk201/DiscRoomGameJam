using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Shake : MonoBehaviour
{
    public float shake_speed;
    public Vector3 originPosition;
 
    public bool isShaking = true;
 
    void Start()
    {
        originPosition = transform.localPosition;
    }
 
    void Update()
    {
        if (isShaking)
        {
            float step = shake_speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, originPosition + Random.insideUnitSphere, step);
        }
    }
}
