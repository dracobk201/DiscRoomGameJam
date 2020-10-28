using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLevelCreator : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private IntVariable currentLevel;
    [SerializeField] private EnemiesSO enemies;
    [SerializeField] private int totalWeight = 1;

    public void CreateEnemies()
    {
        currentLevel.value++;
        totalWeight += currentLevel.value;
        int addedWeight = totalWeight;
        List<EnemyDto> tmp = enemies.enemies.OrderBy(x => Random.Range(0f, 1f)).ToList();
        bool repeat = true;
        while (repeat)
        {
            repeat = false;
            for (int i = 0; i < tmp.Count; i++)
            {
                var item = tmp[i];
                if (item.weight <= addedWeight)
                {
                    addedWeight -= item.weight;
                    repeat = true;
                    i = 9999;
                    Instantiate(item.prefab, positinToInstantiate(), Quaternion.identity);
                    Debug.Log("Instantiated");
                }
            }
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
