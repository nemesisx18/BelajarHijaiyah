﻿using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float localTime = 0;

    public bool timerIsRunning = false;

    public delegate void TimerEvent(bool isWin);
    public static event TimerEvent OnTimeOut;

    private void OnEnable()
    {
        QuestionManager.SetNewTimer += SetTimer;
    }
    private void OnDisable()
    {
        QuestionManager.SetNewTimer -= SetTimer;
    }

    void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            RunTimer();
        }
    }

    public void SetTimer(float time)
    {
        localTime = time;
        timerIsRunning = true;
    }

    public void RunTimer()
    {
        localTime -= Time.deltaTime;

        if(localTime < 0)
        {
            Debug.Log("Timeoutt");
            OnTimeOut?.Invoke(false);

            timerIsRunning = false;
        }

        DisplayTime(localTime);
    }

    [ContextMenu("Save & stop time data")]
    public void StopTimer()
    {
        timerIsRunning = false;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    }


}
