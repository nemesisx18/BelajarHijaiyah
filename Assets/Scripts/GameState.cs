using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private int playerChance = 3;
    [SerializeField] private int questionScore = 10;

    [field: SerializeField] public int PlayerScore { get; private set; } = 0;
    [field: SerializeField] public int LevelIndex { get; private set; } = 1;

    public delegate void GameStateDelegate();
    public static event GameStateDelegate OnGameOver;

    private void OnEnable()
    {
        Question.OnCorrectAnswer += AddScore;
        Question.OnWrongAnswer += ReduceChance;

        QuestionManager.OnQuestionEmpty += GameOver;
    }

    private void OnDisable()
    {
        Question.OnCorrectAnswer -= AddScore;
        Question.OnWrongAnswer -= ReduceChance;

        QuestionManager.OnQuestionEmpty -= GameOver;
    }

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void ReduceChance()
    {
        playerChance--;

        if(playerChance == 0 )
        {
            GameOver();
        }
    }

    private void AddScore()
    {
        PlayerScore += questionScore;
    }

    private void GameOver()
    {
        switch (LevelIndex)
        {
            case 1:
                SaveData.SaveInstance.AddTebakScore(PlayerScore);
                break;
            case 2:
                SaveData.SaveInstance.AddPuzzleScore(PlayerScore);
                break;
            case 3:
                SaveData.SaveInstance.AddTulisScore(PlayerScore);
                break;
        }

        OnGameOver?.Invoke();
        
        Time.timeScale = 0;
    }
}
