using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaveSawHelpUI : MonoBehaviour
{

    [SerializeField] private float disabledOpacity;
    [SerializeField] private Image sawImage;
    [SerializeField] private bool currentStatus;
    [SerializeField] private BoolVariable PlayerHaveDisk;

    void Update()
    {
        if (currentStatus != PlayerHaveDisk.value)
        {
            currentStatus = PlayerHaveDisk.value;
            var tempColor = sawImage.color;
            tempColor.a = currentStatus ? 1f : disabledOpacity;
            sawImage.color = tempColor;
        }
    }
}
