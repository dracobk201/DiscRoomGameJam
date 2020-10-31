using UnityEngine;

public class EnemyDiscBehaviour : MonoBehaviour
{
    [SerializeField] private FloatReference discVelocity = null;
    [SerializeField] private FloatReference discTimeOfLife = null;
    private float _actualTimeProgress;

    private void OnEnable()
    {
        TryGetComponent(out Rigidbody rigidbodyResult);
        Vector3 aux = transform.forward * discVelocity.Value;
        aux.y = 0;
        rigidbodyResult.velocity = aux;
        _actualTimeProgress = discTimeOfLife.Value;
    }

    private void Update()
    {
        _actualTimeProgress -= Time.deltaTime;
        if (_actualTimeProgress <= 0)
            DestroyDisc();
    }

    public void DestroyDisc()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        if (targetTag.Equals(Global.PlayerTag))
            DestroyDisc();
    }
}
