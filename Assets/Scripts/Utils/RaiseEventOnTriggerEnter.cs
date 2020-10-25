using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private GameEvent eventToRaise = null;
    [SerializeField] private List<string> availableTags = null;

    private void OnTriggerEnter(Collider other)
    {
        if (availableTags.Count == 0 || availableTags.FindIndex(x => other.tag.Equals(x)) > -1) { 
            eventToRaise.Raise();
        }
    }
}
