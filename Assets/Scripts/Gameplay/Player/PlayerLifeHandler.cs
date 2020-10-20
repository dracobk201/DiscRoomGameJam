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

    private float timeForWait;

    private void Start()
    {
        timeForWait = 1;
        playerAlive.Value = true;
        actualPlayerLife.Value = maxPlayerLife.Value;
    }

    private void Update()
    {
        timeForWait -= Time.deltaTime;
        if (timeForWait <= 0)
        {
            timeForWait = 1;
            if (!havingDisc.Value && !DebugMode.Value)
                DamageReceived(damageByNoDisc.Value);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.otherCollider.CompareTag(Global.EnemyTag))
                DamageReceived(damageByEnemy.Value);
        }
    }

    private void DamageReceived(float damage)
    {
        actualPlayerLife.Value -= damage;
        playerDamaged.Raise();
        if (actualPlayerLife.Value <= 0)
        {
            playerAlive.Value = false;
            playerDead.Raise();
        }
    }
}
