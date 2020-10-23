using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private LevelsDto levels = null;
    [SerializeField] private Transform[] levelLocations = null;
    [SerializeField] private Vector3Reference nextWarpLocation = null;
    [SerializeField] private GameEvent startLevel = null;
    [SerializeField] private GameEvent teleportPlayer = null;
    [Space(10)]
    [SerializeField] private StringReference levelTitle = null;
    [SerializeField] private StringReference levelMessage = null;
    [SerializeField] private FloatReference actualLevelTime = null;
    
    private int _currentLevelIndex = -1;
    private int _currentLevelLocationIndex = 0;
    private GameObject _currentLevelPrefab = null;
    private GameObject _lastLevelPrefab = null;
    private LevelVariable _currentLevel;

    private void Start()
    {
        LoadLevel();
        SetupValues();
        LoadLevel();
    }

    private void LoadLevel()
    {
        if (_currentLevelPrefab != null)
            _lastLevelPrefab = _currentLevelPrefab;
        _currentLevelIndex++;
        _currentLevel.value = levels.levels[_currentLevelIndex];
        _currentLevelPrefab = Instantiate(_currentLevel.value.levelPrefab, levelLocations[_currentLevelLocationIndex].position, Quaternion.identity);
        
        if (_currentLevelPrefab.TryGetComponent(out LevelDetail levelDatailResult))
            nextWarpLocation.Value = levelDatailResult.GetWarpLocation().position;
        else
            Debug.LogError("There's no next warp location");
        teleportPlayer.Raise();
        if (_currentLevelLocationIndex == 0)
            _currentLevelLocationIndex = 1;
        else if (_currentLevelLocationIndex == 1)
            _currentLevelLocationIndex = 0;
    }

    private void SetupValues()
    {
        levelTitle.Value = _currentLevel.value.id;
        levelMessage.Value = _currentLevel.value.message;
        actualLevelTime.Value = _currentLevel.value.timeToBeat;
        StartCoroutine(WaitForUI());
    }

    private IEnumerator WaitForUI()
    {
        yield return new WaitForSeconds(2);
        startLevel.Raise();
    }

    public void PrepareForNextLevel()
    {
        Destroy(_lastLevelPrefab);
        SetupValues();
        LoadLevel();
    }
}
