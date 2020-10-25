using UnityEngine;

public class EnemyMagazine : MonoBehaviour
{
    [SerializeField] private EnemyRuntimeSet enemies = null;
    [SerializeField] private IntReference enemyPool = null;
    [SerializeField] private GameObject enemyPrefab = null;

    private void Awake()
    {
        enemies.Items.Clear();
        InstantiateEnemy();
    }

    private void InstantiateEnemy()
    {
        for (int i = 0; i < enemyPool.Value; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.GetComponent<Transform>().SetParent(transform);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }
    }
}
