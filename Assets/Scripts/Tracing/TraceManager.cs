using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraceManager : MonoBehaviour
{
    [SerializeField] private QuestionManager questionManager;
    
    [SerializeField] private List<Image> traces = new List<Image>();

    [SerializeField] private GameObject nextLevel;

    [SerializeField] private int traceCount;

    [SerializeField] private bool isLastLevel = false;

    private bool gameEnd = false;
    private int currentIndex = 0;

    private void OnEnable()
    {
        Tracer.OnDoneTracing += OnTraceDone;
    }

    private void OnDisable()
    {
        Tracer.OnDoneTracing -= OnTraceDone;
    }

    private void Start()
    {
        traces[currentIndex].gameObject.SetActive(true);
    }

    private void OnTraceDone()
    {
        traces[currentIndex].enabled = true;

        OnPlayerFinish();

        if(gameEnd)
        {
            return;
        }

        currentIndex++;

        traces[currentIndex].gameObject.SetActive(true);
    }

    private void OnPlayerFinish()
    {
        if (currentIndex + 1 != traceCount)
        {
            return;
        }

        gameEnd = true;

        //nextLevel.SetActive(true);

        questionManager.OnPlayerAnswered();

        gameObject.transform.parent.gameObject.SetActive(false);
        Debug.Log("Finished");
    }
}
