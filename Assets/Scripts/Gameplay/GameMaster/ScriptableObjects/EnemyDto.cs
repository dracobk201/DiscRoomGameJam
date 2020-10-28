using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDefinbition", menuName = "Enemy", order = 51)]
public class EnemyDto : ScriptableObject
{
    public string enemyName;
    public int weight;
    public GameObject prefab;
    //TODO definir los estados de los enmigos
}
