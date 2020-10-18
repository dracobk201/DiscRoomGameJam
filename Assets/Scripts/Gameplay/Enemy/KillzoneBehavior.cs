using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneBehavior : MonoBehaviour
{
    [SerializeField] private GameEvent EnemyDestroyed = null;

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        Debug.Log("ENTRO___" + targetTag);
        if (targetTag.Equals(Global.PlayerDiscTag) && gameObject.tag.Equals(Global.EnemyTag))
        {
            EnemyDestroyed.Raise();
            Destroy(this.gameObject);
        }
    }
}
