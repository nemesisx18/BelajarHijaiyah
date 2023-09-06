using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private List<bool> playerAnswers = new List<bool>();
    [SerializeField] private int puzzleQty = 2;

    private Question question;

    private void OnEnable()
    {
        PuzzleSlot.OnSlotOccupied += AddPlayerAnswer;
    }

    private void OnDisable()
    {
        PuzzleSlot.OnSlotOccupied -= AddPlayerAnswer;
    }

    private void Start()
    {
        question = GetComponent<Question>();
    }

    private void AddPlayerAnswer(bool playerAnswer)
    {
        playerAnswers.Add(playerAnswer);

        CheckAnswer();
    }

    private void CheckAnswer()
    {
        if(playerAnswers.Count < puzzleQty)
        {
            return;
        }

        int index = 0;

        for (int i = 0; i < playerAnswers.Count; i++)
        {
            if (playerAnswers[i] == true)
            {
                index++;
            }
        }

        if(index == puzzleQty)
        {
            question.SetAnswerTrue();
            question.OnPlayerAnswered();
            Debug.Log("Correct");
        }
        else
        {
            question.OnPlayerAnswered();
            Debug.Log("Wrong");
        }
    }
}
