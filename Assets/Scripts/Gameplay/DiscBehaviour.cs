using System.Collections;
using UnityEngine;

public class DiscBehaviour : MonoBehaviour
{
    [SerializeField] private FloatReference discVelocity = null;
    [SerializeField] private FloatReference discTimeOfLife = null;
    [SerializeField] private GameEvent enemyImpacted = null;

    private void OnEnable()
    {
        print("Alive)))");
        TryGetComponent(out Rigidbody rigidbodyResult);
        StartCoroutine(AutoDestruction());
        rigidbodyResult.velocity = transform.forward * discVelocity.Value;
        //rigidbodyResult.AddForce(transform.forward * discVelocity.Value, ForceMode.Impulse);
    }

    private void Destroy()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(discTimeOfLife.Value);
        //Destroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        string targetTag = other.tag;
        Debug.Log("targetTag" + targetTag);
        if (targetTag.Equals(Global.EnemyTag) && gameObject.tag.Equals(Global.PlayerDiscTag))
        {
            enemyImpacted.Raise();
        }
    }

}
