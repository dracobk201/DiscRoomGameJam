using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private IntVariable currentLevel = null;
    [SerializeField] private TextMeshProUGUI gameOverLabel = null;
    private bool _gameOver;

    public void RestartScene()
    {
        if (_gameOver)
            SceneManager.LoadScene(Global.LevelScene);
    }

    public void SetGameOverPanel()
    {
        _gameOver = true;
        gameOverLabel.text = $"You have barely reached\n<b>level {currentLevel.value}</b>\nand the meteor has destroyed you.";
    }
}
