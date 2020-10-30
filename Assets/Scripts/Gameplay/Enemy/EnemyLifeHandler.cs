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
    [SerializeField] private CapsuleCollider capsule = null;

    private float _actualEnemyLife;
    private bool _death = false;

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
        if (_death == false)
        {
            _actualEnemyLife -= damage;
            if (_actualEnemyLife <= 0)
            {
                _death = true;
                enemyDead.Raise();
                StartCoroutine(LeftToDEath());
            }
            else
                enemyDamaged.Raise();
        }
    }

    private IEnumerator LeftToDEath()
    {
        capsule.enabled = false;
        particles.gameObject.SetActive(true);
        spriteHolder.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        particles.gameObject.SetActive(false);
        spriteHolder.SetActive(true);
        capsule.enabled = true;

    }
}
