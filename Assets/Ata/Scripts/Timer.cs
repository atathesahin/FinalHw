using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public TextMeshProUGUI timerText;
    

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    private void DisplayTime(float display)
    {
        if (display < 0)
        {
            display = 0;
        }

        float minutes = Mathf.FloorToInt(display / 60);
        float seconds = Mathf.FloorToInt(display % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

