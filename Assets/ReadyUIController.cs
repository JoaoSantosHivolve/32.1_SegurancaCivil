using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUIController : MonoBehaviour
{
    public Image loadingBar;
    public Gradient overTimeGradient;
    public TextMeshProUGUI timer;

    public void UpdateBar(float time, int timerDuration)
    {
        loadingBar.fillAmount = time;
        loadingBar.color = overTimeGradient.Evaluate(time);
        timer.text = timerDuration.ToString();
    }
}
