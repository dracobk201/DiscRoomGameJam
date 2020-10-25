using UnityEngine;

public class EnemyLifeHandler : MonoBehaviour
{
    [SerializeField] private FloatReference maxEnemyLife = null;
    [SerializeField] private GameEvent enemyDamaged = null;
    [SerializeField] private GameEvent enemyDead = null;

    private float _actualEnemyLife;

    private void OnEnable()
    {
        _actualEnemyLife = maxEnemyLife.Value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.otherCollider.CompareTag(Global.PlayerDiscTag))
                DamageReceived(1);
        }
    }

    private void DamageReceived(float damage)
    {
        _actualEnemyLife -= damage;
        if (_actualEnemyLife <= 0)
        {
            enemyDead.Raise();
            gameObject.SetActive(false);
        }
        else
            enemyDamaged.Raise();
    }
}
