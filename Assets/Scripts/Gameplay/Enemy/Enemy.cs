using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyRuntimeSet enemies = null;

    private void OnEnable()
    {
        enemies.Add(this);
    }

    private void OnDisable()
    {
        enemies.Remove(this);
    }
}
