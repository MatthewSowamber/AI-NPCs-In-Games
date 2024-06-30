using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimeNO;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }
        else
        {
            TimeLeft = 0;
            TimerOn = false;
        }

        if(TimeLeft == 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimeNO.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
