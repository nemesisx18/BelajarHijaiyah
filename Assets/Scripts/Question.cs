using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField] private bool isCorrectAnswer = false;
    [SerializeField] private bool isTebakMode = false;

    private Button submitButton;

    public delegate void QuestionAnswerDelegate();
    public static event QuestionAnswerDelegate OnWrongAnswer;
    public static event QuestionAnswerDelegate OnCorrectAnswer;

    private void Start()
    {
        if (!isTebakMode)
        {
            return;
        }

        submitButton = GetComponent<Button>();

        submitButton.onClick.AddListener(OnPlayerAnswered);
    }

    public void SetQuestionAnswer(bool answer)
    {
        isCorrectAnswer = answer;
    }

    public void OnPlayerAnswered()
    {
        switch (isCorrectAnswer)
        {
            case true:
                OnCorrectAnswer?.Invoke();

                Debug.Log("Correct");
                break;
            case false:
                OnWrongAnswer?.Invoke();

                Debug.Log("Wrong");
                break;
        }
    }

    public void SetAnswerTrue()
    {
        isCorrectAnswer = true;
    }
}
