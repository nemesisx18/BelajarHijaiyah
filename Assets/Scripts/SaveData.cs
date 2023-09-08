using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private List<int> tebakHijaiyahScores = new List<int>();
    [SerializeField] private List<int> puzzleHijaiyahScores = new List<int>();
    [SerializeField] private List<int> tulisHijaiyahScores = new List<int>();

    [SerializeField] private int totalScoreTebak;
    [SerializeField] private int totalScorePuzzle;
    [SerializeField] private int totalScoreTulis;

    public static SaveData SaveInstance;

    public List<int> TebakHijaiyahScores => tebakHijaiyahScores;
    public List<int> PuzzleHijaiyahScores => puzzleHijaiyahScores;
    public List<int> TulisHijaiyahScores => tulisHijaiyahScores;

    public int TotalScoreTebak => totalScoreTebak;
    public int TotalScorePuzzle => totalScorePuzzle;
    public int TotalScoreTulis => totalScoreTulis;

    private const string _prefsKey = "ScoreHijaiyah";

    private void Awake()
    {
        if (SaveInstance == null)
        {
            SaveInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Load();
    }

    private void Start()
    {
        if (tebakHijaiyahScores.Count == 0)
        {
            for (int i = 0; i < 6; i++)
            {
                tebakHijaiyahScores.Add(0);
            }
        }

        if (puzzleHijaiyahScores.Count == 0)
        {
            for (int i = 0; i < 6; i++)
            {
                puzzleHijaiyahScores.Add(0);
            }
        }

        if(tulisHijaiyahScores.Count == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                tulisHijaiyahScores.Add(0);
            }
        }
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_prefsKey))
        {
            string json = PlayerPrefs.GetString(_prefsKey);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            Save();
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(_prefsKey, json);
    }

    public void AddTebakScore(int score, int levelIndex)
    {
        if (score < tebakHijaiyahScores[levelIndex])
        {
            return;
        }

        tebakHijaiyahScores[levelIndex] = score;

        for (int i = 0; i < tebakHijaiyahScores.Count; i++)
        {
            totalScoreTebak += tebakHijaiyahScores[i]; 
        }

        Save();
    }
    public void AddPuzzleScore(int score, int levelIndex)
    {
        if (score < puzzleHijaiyahScores[levelIndex])
        {
            return;
        }

        puzzleHijaiyahScores[levelIndex] = score;

        for (int i = 0; i < puzzleHijaiyahScores.Count; i++)
        {
            totalScorePuzzle += puzzleHijaiyahScores[i];
        }

        Save();
    }
    public void AddTulisScore(int score, int levelIndex)
    {
        if (score < tulisHijaiyahScores[levelIndex])
        {
            return;
        }

        tulisHijaiyahScores[levelIndex] = score;

        for (int i = 0; i < tulisHijaiyahScores.Count; i++)
        {
            totalScoreTulis += tulisHijaiyahScores[i];
        }

        Save();
    }
}
