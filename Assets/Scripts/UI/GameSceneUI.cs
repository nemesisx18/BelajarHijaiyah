using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    
    [SerializeField] private Slider timerSlider;

    [SerializeField] private Button homeButton;

    [SerializeField] private Text highscoreText;
    [SerializeField] private Text currentScoreText;

    [SerializeField] private GameObject wrongPopup;
    [SerializeField] private GameObject correctPopup;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject[] healthBars;

    [SerializeField] private float delayTime;

    [SerializeField] private bool hasScoring = true;

    [Header("Game Over UI")]
    [SerializeField] private Button menuButton;
    [SerializeField] private Button retryButton;

    [SerializeField] private GameObject[] stars;
    
    private Timer time;

    private int healthIndex = 0;

    private void OnEnable()
    {
        QuestionManager.SetNewTimer += SetTimerSlider;

        Question.OnWrongAnswer += ShowFalsePanel;
        Question.OnCorrectAnswer += ShowCorrectPanel;

        GameState.OnGameOver += ShowGameOverPanel;
    }
    private void OnDisable()
    {
        QuestionManager.SetNewTimer -= SetTimerSlider;

        Question.OnWrongAnswer -= ShowFalsePanel;
        Question.OnCorrectAnswer -= ShowCorrectPanel;

        GameState.OnGameOver -= ShowGameOverPanel;
    }

    private void Start()
    {
        time = GetComponent<Timer>();

        homeButton.onClick.AddListener(ReturnHome);
        menuButton.onClick.AddListener(ReturnHome);
        retryButton.onClick.AddListener(RetryGame);
    }

    private void Update()
    {
        timerSlider.value = time.localTime;

        if (hasScoring)
        {
            currentScoreText.text = gameState.PlayerScore.ToString();

            switch (gameState.LevelIndex)
            {
                case 1:
                    highscoreText.text = "Hi-Skor: " + SaveData.SaveInstance.TebakHijaiyahScores.ToString();
                    break;
                case 2:
                    highscoreText.text = "Hi-Skor: " + SaveData.SaveInstance.PuzzleHijaiyahScores.ToString();
                    break;
                case 3:
                    highscoreText.text = "Hi-Skor: " + SaveData.SaveInstance.TulisHijaiyahScores.ToString();
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

    public void ChangeHealthValue()
    {
        healthBars[healthIndex].SetActive(false);

        healthIndex++;
    }

    private void SetTimerSlider(float value)
    {
        timerSlider.maxValue = value;
    }

    private void ShowFalsePanel()
    {
        StartCoroutine(DeactiveGameobject(wrongPopup));

        ChangeHealthValue();
    }
    private void ShowCorrectPanel()
    {
        StartCoroutine(DeactiveGameobject(correctPopup));
    }

    private void ShowGameOverPanel()
    {
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
        
        gameOverPanel.SetActive(true);
    }

    private IEnumerator DeactiveGameobject(GameObject obj)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(delayTime);

        obj.SetActive(false);
    }
}
