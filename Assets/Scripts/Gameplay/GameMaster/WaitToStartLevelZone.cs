using UnityEngine;

public class WaitToStartLevelZone : MonoBehaviour
{
    [SerializeField] private GameEvent waitingForStartLevel = null;

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.PlayerTag))
            waitingForStartLevel.Raise();
    }
}
