using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLevelCreator : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LevelVariable currentLevel;

    public void CreateEnemies()
    {
        foreach (var item in currentLevel.value.enemies)
        {
            Instantiate(item.prefab, positinToInstantiate(), Quaternion.identity);
        }
    }

    public Vector3 positinToInstantiate()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
