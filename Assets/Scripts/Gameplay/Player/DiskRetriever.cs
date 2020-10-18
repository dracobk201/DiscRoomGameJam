using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskRetriever : MonoBehaviour
{
    [SerializeField] private GameEvent diskRetrieved = null;

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        Debug.Log("targetTag" + targetTag);
        if (targetTag.Equals(Global.PlayerDiscTag) && gameObject.tag.Equals(Global.PlayerDiscTag))
        {
            diskRetrieved.Raise();
            Destroy(other.gameObject);
        }
    }
}
