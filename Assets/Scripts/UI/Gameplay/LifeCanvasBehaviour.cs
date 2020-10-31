using UnityEngine;
using UnityEngine.UI;

public class LifeCanvasBehaviour : MonoBehaviour
{
    [SerializeField] private FloatReference maxPlayerLife = null;
    [SerializeField] private FloatReference actualPlayerLife = null;
    [SerializeField] private Image lifeGaugeImage = null;

    private void Start()
    {
        UpdateLifeGauge();
    }

    public void UpdateLifeGauge()
    {
        lifeGaugeImage.fillAmount = actualPlayerLife.Value / maxPlayerLife.Value;
    }
}