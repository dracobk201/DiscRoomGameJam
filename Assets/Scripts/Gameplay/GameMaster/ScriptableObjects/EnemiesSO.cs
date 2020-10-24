using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemies", menuName = "DISCROOM/Enemy", order = 51)]
public class EnemiesSO : ScriptableObject
{
   public List<EnemyDto> enemies;
}
