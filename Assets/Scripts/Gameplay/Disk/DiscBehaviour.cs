using UnityEngine;

public class DiscBehaviour : MonoBehaviour
{
    [SerializeField] private FloatReference discVelocity = null;
    [SerializeField] private FloatReference discTimeOfLife = null;
    [SerializeField] private GameObject discGameplaySprite = null;
    [SerializeField] private GameObject discVerticalSprite = null;
    [SerializeField] private GameEvent enemyImpacted = null;
    private float _actualTimeProgress;
    private Rigidbody discRigidbody;

    private void OnEnable()
    {
        if (TryGetComponent(out Rigidbody rigidbodyResult))
            discRigidbody = rigidbodyResult;
        else
            Debug.LogError("No Rigidbody found");
        Vector3 aux = transform.forward * discVelocity.Value;
        aux.y = 0;
        rigidbodyResult.velocity = aux;
        _actualTimeProgress = discTimeOfLife.Value;
        discGameplaySprite.SetActive(true);
        discVerticalSprite.SetActive(false);
    }

    private void Update()
    {
        _actualTimeProgress -= Time.deltaTime;
        if (_actualTimeProgress <= 0)
        {
            discRigidbody.velocity = Vector3.zero;
            discGameplaySprite.SetActive(false);
            discVerticalSprite.SetActive(true);
        }
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
