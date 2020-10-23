using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetail : MonoBehaviour
{
    [SerializeField] private Transform warpLocation = null;

    public Transform GetWarpLocation()
    {
        return warpLocation;
    }
}
