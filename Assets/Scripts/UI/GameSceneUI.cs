using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    
    [SerializeField] private Button homeButton;

    [SerializeField] private Text timerText;
    [SerializeField] private Text highscoreText;
    [SerializeField] private Text currentScoreText;

    [SerializeField] private GameObject wrongPopup;
    [SerializeField] private GameObject correctPopup;
    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject[] healthBars;

    [SerializeField] private float delayTime;

    [SerializeField] private bool hasScoring = true;

    [Header("Game Win UI")]
    [SerializeField] private Text scoreModeText;

    [SerializeField] private Button menuButton;
    [SerializeField] private Button nextLevelButton;

    [SerializeField] private GameObject[] stars;

    [SerializeField] private string nextLevelSceneName;

    [Header("Game Over UI")]
    [SerializeField] private Text scoreOverText;

    [SerializeField] private Button menuOverButton;
    [SerializeField] private Button retryButton;

    [Header("Audio Config")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip benarClip;
    [SerializeField] private AudioClip salahClip;

    private Timer time;

    private int healthIndex = 0;

    private void OnEnable()
    {
        Question.OnWrongAnswer += ShowFalsePanel;
        Question.OnCorrectAnswer += ShowCorrectPanel;

        GameState.OnGameOver += ShowGameOverPanel;
    }
    private void OnDisable()
    {
        Question.OnWrongAnswer -= ShowFalsePanel;
        Question.OnCorrectAnswer -= ShowCorrectPanel;

        GameState.OnGameOver -= ShowGameOverPanel;
    }

    private void Start()
    {
        time = GetComponent<Timer>();

        homeButton.onClick.AddListener(ReturnHome);
        menuButton.onClick.AddListener(ReturnHome);
        menuOverButton.onClick.AddListener(ReturnHome);
        retryButton.onClick.AddListener(RetryGame);
        nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void Update()
    {
        time.DisplayTime(time.localTime, timerText);

        if (hasScoring)
        {
            scoreModeText.text = "Skor: " + gameState.PlayerScore.ToString();
            scoreOverText.text = "Skor: " + gameState.PlayerScore.ToString();

            currentScoreText.text = gameState.PlayerScore.ToString();

            switch (gameState.ModeIndex)
            {
                case 1:
                    highscoreText.text = SaveData.SaveInstance.TotalScoreTebak.ToString();
                    break;
                case 2:
                    highscoreText.text = SaveData.SaveInstance.TotalScorePuzzle.ToString();
                    break;
                case 3:
                    highscoreText.text = SaveData.SaveInstance.TotalScoreTulis.ToString();
                    break;
            }
        }
    }

    private void ReturnHome()
    {
        SceneManager.LoadScene("Menu");
    }

    private void RetryGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(nextLevelSceneName);
    }

    public void ChangeHealthValue()
    {
        healthBars[healthIndex].SetActive(false);

        healthIndex++;
    }

    private void ShowFalsePanel()
    {
        source.PlayOneShot(salahClip);
        
        StartCoroutine(DeactiveGameobject(wrongPopup));

        ChangeHealthValue();
    }
    public void ShowCorrectPanel()
    {
        source.PlayOneShot(benarClip);

        StartCoroutine(DeactiveGameobject(correctPopup));
    }

    private void ShowGameOverPanel(bool isWin = true)
    {
        if(!isWin)
        {
            gameOverPanel.SetActive(true);

            return;
        }
        
        switch(gameState.PlayerScore)
        {
            case 60:
                for (int i = 0; i < stars.Length; i++)
                {
                    stars[i].SetActive(true);
                }
                break;
            case 50:
                for (int i = 0; i < 2; i++)
                {
                    stars[i].SetActive(true);
                }
                break;
            case 40:
                for (int i = 0; i < 2; i++)
                {
                    stars[i].SetActive(true);
                }
                break;
            case 30:
                for (int i = 0; i < 2; i++)
                {
                    stars[i].SetActive(true);
                }
                break;
            case 20:
                stars[0].SetActive(true);
                break;
            case 10:
                stars[0].SetActive(true);
                break;
        }
        
        gameWinPanel.SetActive(true);
    }

    private IEnumerator DeactiveGameobject(GameObject obj)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(delayTime);

        obj.SetActive(false);
    }
}
