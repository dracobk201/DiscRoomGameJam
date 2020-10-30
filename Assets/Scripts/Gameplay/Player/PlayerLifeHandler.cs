using UnityEngine;

public class PlayerLifeHandler : MonoBehaviour
{
    [SerializeField] private BoolReference DebugMode = null;
    [SerializeField] private BoolReference playerAlive = null;
    [SerializeField] private BoolReference havingDisc = null;
    [SerializeField] private FloatReference maxPlayerLife = null;
    [SerializeField] private FloatReference actualPlayerLife = null;
    [SerializeField] private FloatReference damageByEnemy = null;
    [SerializeField] private FloatReference damageByNoDisc = null;
    [SerializeField] private GameEvent playerDamaged = null;
    [SerializeField] private GameEvent playerDead = null;

    private bool _havingDiscLastTime;
    private float _timeForWait;

    private void Start()
    {
        _timeForWait = 1;
        playerAlive.Value = true;
        _havingDiscLastTime = true;
        actualPlayerLife.Value = maxPlayerLife.Value;
    }

    private void Update()
    {
        if (DebugMode.Value) return;

        _timeForWait -= Time.deltaTime;
        if (_timeForWait <= 0)
        {
            _timeForWait = 1;
            if (!havingDisc.Value)
            {
                if (_havingDiscLastTime)
                {
                    _havingDiscLastTime = false;
                    return;
                }
                else
                    DamageReceived(damageByNoDisc.Value);
            }
            else
                _havingDiscLastTime = true;
        }
    }

    /*
        private void OnCollisionEnter(Collision collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (contact.otherCollider.CompareTag(Global.EnemyTag))
                    DamageReceived(damageByEnemy.Value);
            }
        }
        */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Global.EnemyTag))
            DamageReceived(damageByEnemy.Value);
    }


    private void DamageReceived(float damage)
    {
        Debug.Log("AUCH");
        actualPlayerLife.Value -= damage;
        playerDamaged.Raise();
        if (actualPlayerLife.Value <= 0)
        {
            playerAlive.Value = false;
            playerDead.Raise();
        }
    }
}
