using UnityEngine;

public class DiscGunRetriever : MonoBehaviour
{
    [SerializeField] private BoolReference gunCollected = null;
    [SerializeField] private GameEvent onGunTaken = null;

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.CompareTag(Global.PlayerTag))
        {
            gunCollected.Value = true;
            gameObject.SetActive(false);
            onGunTaken.Raise();
        }
    }
}
