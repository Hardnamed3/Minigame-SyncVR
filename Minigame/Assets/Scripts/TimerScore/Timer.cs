using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float TimePassed { get; set; }
    public bool TimerOn;

    public Text TimerText;

    private void Update()
    {
        if (TimerOn)
        {
            TimePassed += Time.deltaTime;
            VisualizeTimer(TimePassed);
        }
    }

    private void VisualizeTimer(float currentTime) 
    {
        currentTime += 1;

        string minutes = Mathf.FloorToInt(currentTime / 60).ToString();
        string seconds = Mathf.FloorToInt(currentTime % 60).ToString();
        
        string text = minutes + ":" + seconds;
        TimerText.text = text;
    }
}
