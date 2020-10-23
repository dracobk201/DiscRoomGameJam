using UnityEngine;

public class LevelFinishedZone : MonoBehaviour
{
    [SerializeField] private GameEvent levelFinished = null;

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.PlayerTag))
            levelFinished.Raise();
    }
}
