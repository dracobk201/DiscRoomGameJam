using UnityEngine;

public class DiscBehaviour : MonoBehaviour
{
    [SerializeField] private FloatReference discVelocity = null;
    [SerializeField] private GameEvent enemyImpacted = null;

    private void OnEnable()
    {
        TryGetComponent(out Rigidbody rigidbodyResult);
        Vector3 aux = transform.forward * discVelocity.Value;
        aux.y = 0;
        rigidbodyResult.velocity = aux;
    }

    private void DestroyDisc()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.EnemyTag))
            enemyImpacted.Raise();
        else if (targetTag.Equals(Global.DiscRetrieverTag))
            DestroyDisc();
    }
}
