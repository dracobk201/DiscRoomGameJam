using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    [SerializeField] private DiscsRuntimeSet bullets = null;
    [SerializeField] private GameEvent enemyShot = null;
    [SerializeField] private Transform bulletInitialPosition = null;
    private bool _playerFound = false;
    private float _timeToWait = 0f;

    private void Update()
    {
        if (!_playerFound) return;
        
        _timeToWait -= Time.deltaTime;
        if (_timeToWait <= 0)
        {
            ShootBullet();
            _timeToWait = 2f;
        }
    }

    private void ShootBullet()
    {
        var initialPosition = bulletInitialPosition.position;
        var initialRotation = bulletInitialPosition.rotation;

        for (int i = 0; i < bullets.Items.Count; i++)
        {
            if (!bullets.Items[i].activeInHierarchy)
            {
                bullets.Items[i].transform.localPosition = initialPosition;
                bullets.Items[i].transform.localRotation = initialRotation;
                bullets.Items[i].SetActive(true);
                enemyShot.Raise();
                break;
            }
        }
    }

    public void PlayerFound()
    {
        _playerFound = true;
    }
}
