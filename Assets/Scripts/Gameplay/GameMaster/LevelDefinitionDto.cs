using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDefinition", menuName = "Level", order = 51)]
public class LevelDefinitionDto : ScriptableObject
{
    public string id;
    public List<EnemyDto> enemies;
}
