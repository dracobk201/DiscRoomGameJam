using TMPro;
using UnityEngine;

public class TimerCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyRuntimeSet enemies = null;
    [SerializeField] private FloatReference actualTimeProgress = null;
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private TextMeshProUGUI enemyRemainingText = null;

    private float _timeForWait;

    private void Start()
    {
        _timeForWait = 1;
        SetupLabels();
    }

    private void Update()
    {
        _timeForWait -= Time.deltaTime;
        if (_timeForWait <= 0)
        {
            SetupLabels();
            _timeForWait = 1;
        }
    }

    private void SetupLabels()
    {
        enemyRemainingText.text = enemies.Items.Count.ToString();
        timerText.text = Global.ReturnTimeToString(actualTimeProgress.Value);
    }

    public void UpdateEnemyCounter()
    {
        enemyRemainingText.text = enemies.Items.Count.ToString();
    }
}
