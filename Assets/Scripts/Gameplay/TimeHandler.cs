using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] private FloatReference actualLevelTime = null;
    [SerializeField] private FloatReference actualTimeProgress = null;
    [SerializeField] private GameEvent timesUp = null;
    private bool _timesUp;

    private void Start()
    {
        _timesUp = true;
        actualTimeProgress.Value = actualLevelTime.Value;
    }

    private void Update()
    {
        CheckRemainingTime();
    }

    public void SetupTimer()
    {
        _timesUp = false;
        actualTimeProgress.Value = actualLevelTime.Value;
    }

    private void CheckRemainingTime()
    {
        if (_timesUp) return;
        actualTimeProgress.Value -= Time.deltaTime;
        if (actualTimeProgress.Value <= 0)
        {
            _timesUp = true;
            timesUp.Raise();
        }
    }
}
