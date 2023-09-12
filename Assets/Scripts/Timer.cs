using UnityEngine;
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

        Question.OnCorrectAnswer += StopTimer;
        Question.OnWrongAnswer += StopTimer;
    }
    private void OnDisable()
    {
        QuestionManager.SetNewTimer -= SetTimer;

        Question.OnCorrectAnswer -= StopTimer;
        Question.OnWrongAnswer -= StopTimer;
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
    }

    [ContextMenu("Save & stop time data")]
    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void DisplayTime(float timeToDisplay, Text timeText = null)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
