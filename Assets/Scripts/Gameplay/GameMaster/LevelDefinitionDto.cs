using UnityEngine;

[CreateAssetMenu(fileName = "LevelDefinition", menuName = "Level", order = 51)]
public class LevelDefinitionDto : ScriptableObject
{
    public string id;
    [TextArea]
    public string message;
    public GameObject levelPrefab;
    public float timeToBeat;
}
