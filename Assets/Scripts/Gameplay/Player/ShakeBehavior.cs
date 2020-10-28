using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    public FloatVariable distance;
    public Shake shake;
    public float breakPoint;
    // Start is called before the first frame update
    void Start()
    {
        shake.shake_speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        shake.shake_speed = (breakPoint - distance.value) /12 ;
    }
}
