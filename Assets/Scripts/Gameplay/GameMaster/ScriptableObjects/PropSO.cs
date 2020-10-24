using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prop", menuName = "DISCROOM/Prop", order = 51)]
public class PropSO : ScriptableObject
{
    public float scaleRange = 0f;
    public float rotationRange = 0f;
    public Vector3 positionRange = Vector3.zero;
    public string propName;
    public bool randomizable;
    public PropType propType;
    public GameObject prefab;
}

public enum PropType
{
    Any,
    Corner,
    Wall,
    OverWall, //parales
    CenterFlor, //Stuff like carpets
}
