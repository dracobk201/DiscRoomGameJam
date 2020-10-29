using TMPro;
using UnityEngine;

public class GameOverCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private IntVariable currentLevel = null;
    [SerializeField] private TextMeshProUGUI gameOverLabel = null;

    public void SetGameOverPanel()
    {
        gameOverLabel.text = $"You have barely reached\n<b>level {currentLevel.value}</b>\nand the meteor has destroyed you.";
    }
}
