using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private int tebakHijaiyahScores;
    [SerializeField] private int puzzleHijaiyahScores;
    [SerializeField] private int tulisHijaiyahScores;

    public static SaveData SaveInstance;

    public int TebakHijaiyahScores => tebakHijaiyahScores;
    public int PuzzleHijaiyahScores => puzzleHijaiyahScores;
    public int TulisHijaiyahScores => tulisHijaiyahScores;

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

    public void AddTebakScore(int score)
    {
        if (score < tebakHijaiyahScores)
        {
            return;
        }

        tebakHijaiyahScores = score;

        Save();
    }
    public void AddPuzzleScore(int score)
    {
        if (score < puzzleHijaiyahScores)
        {
            return;
        }

        puzzleHijaiyahScores = score;

        Save();
    }
    public void AddTulisScore(int score)
    {
        if (score < tulisHijaiyahScores)
        {
            return;
        }

        tulisHijaiyahScores = score;

        Save();
    }
}
