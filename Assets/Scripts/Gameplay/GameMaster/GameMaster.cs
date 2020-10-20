using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int currentLevelIndex = -1;
    public LevelsDto levels;
    public GameEvent CreateEnemies;
    public GameEvent StartLevel;
    public LevelVariable currentLevel;
    [SerializeField] private FloatReference actualLevelTime = null;
        
    private void Start()
    {
        LoadNewLevel();
    }

    private void LoadNewLevel()
    {
        currentLevelIndex++;
        currentLevel.value = levels.levels[currentLevelIndex];
        actualLevelTime.Value = currentLevel.value.timeToBeat;
        CreateEnemies.Raise();
        StartCoroutine(waitForUI());
    
    }

    private IEnumerator waitForUI()
    {
        yield return new WaitForSeconds(2);
        StartLevel.Raise();

    }
}
