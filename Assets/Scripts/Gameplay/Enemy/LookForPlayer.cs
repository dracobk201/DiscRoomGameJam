using UnityEngine;
using UnityEngine.Events;

public class LookForPlayer : MonoBehaviour
{
    public UnityEvent RaiseOnPlayerLook;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Global.PlayerTag))
            RaiseOnPlayerLook.Invoke();
    }
}
