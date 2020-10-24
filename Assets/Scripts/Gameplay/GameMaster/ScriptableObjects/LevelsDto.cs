using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDefinition", menuName = "Levels", order = 51)]
public class LevelsDto : ScriptableObject
{
    public string id;
    public List<LevelDefinitionDto> levels;
}
