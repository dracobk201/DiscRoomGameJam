using TMPro;
using UnityEngine;

public class InitialInfoCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private StringReference levelTitle = null;
    [SerializeField] private StringReference levelMessage = null;
    [SerializeField] private TextMeshProUGUI levelTitleText = null;
    [SerializeField] private TextMeshProUGUI levelMessageText = null;

    public void SetupUI()
    {
        levelTitleText.text = $"Level {levelTitle.Value}";
        levelMessageText.text = levelMessage.Value;
    }
}
