using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> questions = new List<GameObject>();

    [SerializeField] private int currentLevel = 0;

    [SerializeField] private float waitTime;

    private int randomIndex;

    public delegate void QuestionTime(float timer);
    public static event QuestionTime SetNewTimer;

    public delegate void QuestionEnd();
    public static event QuestionEnd OnQuestionEmpty;

    private void OnEnable()
    {
        Question.OnWrongAnswer += OnPlayerAnswered;
        Question.OnCorrectAnswer += OnPlayerAnswered;
    }

    private void OnDisable()
    {
        Question.OnWrongAnswer -= OnPlayerAnswered;
        Question.OnCorrectAnswer -= OnPlayerAnswered;
    }

    private void Start()
    {
        ShowQuestion();
        SetTimerLevel();
    }

    private void ShowQuestion()
    {
        if(questions.Count == 0)
        {
            OnQuestionEmpty?.Invoke();
            
            Debug.Log("End");

            return;
        }
        
        randomIndex = RandomizeIndex();

        questions[randomIndex].SetActive(true);

        currentLevel++;
    }

    private void NextQuestion()
    {
        questions[randomIndex].SetActive(false);
        questions.RemoveAt(randomIndex);

        ShowQuestion();

        SetTimerLevel();
    }

    private void SetTimerLevel()
    {
        switch(currentLevel)
        {
            case 1:
                SetNewTimer?.Invoke(20f);
                break;
            case 2:
                SetNewTimer?.Invoke(20f);
                break;
            case 3:
                SetNewTimer?.Invoke(20f);
                break;
            case 4:
                SetNewTimer?.Invoke(15f);
                break;
            case 5:
                SetNewTimer?.Invoke(15f);
                break;
            case 6:
                SetNewTimer?.Invoke(15f);
                break;
        }
    }

    private void OnPlayerAnswered()
    {
        StartCoroutine(DelayShowQuestion());
    }

    private int RandomizeIndex()
    {
        return Random.Range(0, questions.Count);
    }

    private IEnumerator DelayShowQuestion()
    {
        yield return new WaitForSeconds(waitTime);

        NextQuestion();
    }
}
