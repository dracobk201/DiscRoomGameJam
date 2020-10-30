using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtBehavior : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Image HurtVisualHelpImage;
    private int currentHurt;

    public void GotDamage () 
    {
        currentHurt = 180;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHurt> 0) {
            currentHurt-=speed;
            var tempColor = HurtVisualHelpImage.color;
            tempColor.a = currentHurt/255f;
            HurtVisualHelpImage.color = tempColor;
        }
    }
}
