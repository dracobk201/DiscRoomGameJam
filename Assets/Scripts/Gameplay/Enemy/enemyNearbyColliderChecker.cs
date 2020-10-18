using UnityEngine;

public class enemyNearbyColliderChecker : MonoBehaviour
{
    [SerializeField] private AvoidPlayer avoidPlayer = null;

    private void OnTriggerStay(Collider other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.PlayerTag))
        {
            avoidPlayer.alert(other.transform);
        }
    }
}
