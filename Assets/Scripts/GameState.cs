using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private int playerChance = 3;
    [SerializeField] private int questionScore = 10;

    [field: SerializeField] public int PlayerScore { get; private set; } = 0;


    [field: Header("Level setup")]
    [field: SerializeField] public int ModeIndex { get; private set; } = 1;

    [field: SerializeField] public int LevelIndex { get; private set; }

    public delegate void GameStateDelegate(bool isWin);
    public static event GameStateDelegate OnGameOver;

    private void OnEnable()
    {
        if(ModeIndex == 3)
        {
            TraceManager.OnTracingDone += AddScore;
        }
        
        Question.OnCorrectAnswer += AddScore;
        Question.OnWrongAnswer += ReduceChance;

        Timer.OnTimeOut += GameOver;
        QuestionManager.OnQuestionEmpty += GameOver;
    }

    private void OnDisable()
    {
        if (ModeIndex == 3)
        {
            TraceManager.OnTracingDone -= AddScore;
        }

        Question.OnCorrectAnswer -= AddScore;
        Question.OnWrongAnswer -= ReduceChance;

        Timer.OnTimeOut -= GameOver;
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
            GameOver(false);
        }
    }

    public void AddScore()
    {
        PlayerScore += questionScore;
    }

    private void GameOver(bool isWin = true)
    {
        switch (ModeIndex)
        {
            case 1:
                SaveData.SaveInstance.AddTebakScore(PlayerScore, LevelIndex);
                break;
            case 2:
                SaveData.SaveInstance.AddPuzzleScore(PlayerScore, LevelIndex);
                break;
            case 3:
                SaveData.SaveInstance.AddTulisScore(PlayerScore, LevelIndex);
                break;
        }

        if (!isWin)
        {
            OnGameOver?.Invoke(false);
            return;
        }

        OnGameOver?.Invoke(true);
        
        Time.timeScale = 0;
    }
}
