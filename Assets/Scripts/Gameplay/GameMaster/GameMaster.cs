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
    // Start is called before the first frame update
    void Start()
    {
        LoadNewLevel();
    }

    private void LoadNewLevel()
    {
        currentLevelIndex++;
        currentLevel.value = levels.levels[currentLevelIndex];
        CreateEnemies.Raise();
        StartCoroutine(waitForUI());
    
    }

    private IEnumerator waitForUI()
    {
        yield return new WaitForSeconds(2);
        StartLevel.Raise();

    }
}
