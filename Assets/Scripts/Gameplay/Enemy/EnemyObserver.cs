using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObserver : MonoBehaviour
{
    [SerializeField] private IntVariable numberOfEnemies;
    [SerializeField] private GameEvent levelCompleted;

    public void OnEnemyKilled()
    {
        numberOfEnemies.value--;
        if (numberOfEnemies.value == 0)
            levelCompleted.Raise();
    }

    public void OnEnemyCreated()
    {
        numberOfEnemies.value++;

    }
}
