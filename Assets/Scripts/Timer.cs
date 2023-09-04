using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float localTime = 0;

    public bool timerIsRunning = false;

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
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
