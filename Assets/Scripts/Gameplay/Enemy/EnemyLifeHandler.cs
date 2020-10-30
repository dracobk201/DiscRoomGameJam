using UnityEngine;
using System;
using System.Collections;

public class EnemyLifeHandler : MonoBehaviour
{
    [SerializeField] private FloatReference maxEnemyLife = null;
    [SerializeField] private GameEvent enemyDamaged = null;
    [SerializeField] private GameEvent enemyDead = null;
    [SerializeField] private ParticleSystem particles = null;
    [SerializeField] private GameObject spriteHolder = null;

    private float _actualEnemyLife;

    private void OnEnable()
    {
        _actualEnemyLife = maxEnemyLife.Value;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(Global.PlayerDiscTag))
            DamageReceived(1);
    }

    private void DamageReceived(float damage)
    {
        _actualEnemyLife -= damage;
        if (_actualEnemyLife <= 0)
        {
            enemyDead.Raise();
            StartCoroutine(LeftToDEath());
        }
        else
            enemyDamaged.Raise();
    }

    private IEnumerator LeftToDEath()
    {
        particles.gameObject.SetActive(true);
        spriteHolder.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        particles.gameObject.SetActive(false);
        spriteHolder.SetActive(true);
    }
}
