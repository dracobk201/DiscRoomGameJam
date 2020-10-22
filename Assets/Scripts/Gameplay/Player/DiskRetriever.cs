using UnityEngine;

public class DiskRetriever : MonoBehaviour
{
    [SerializeField] private GameEvent diskRetrieved = null;

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.PlayerDiscTag))
            diskRetrieved.Raise();
    }
}
