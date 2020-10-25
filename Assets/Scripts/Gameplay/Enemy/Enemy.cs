using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyRuntimeSet enemies = null;

    private void OnEnable()
    {
        enemies.Add(gameObject);
    }

    private void OnDisable()
    {
        enemies.Remove(gameObject);
    }
}
