using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private Slider timerSlider;

    [SerializeField] private Button homeButton;

    [SerializeField] private Text highscoreText;
    [SerializeField] private Text currentScoreText;

    [SerializeField] private GameObject[] healthBars;
    
    private Timer time;

    private int healthIndex = 0;

    private void Start()
    {
        time = GetComponent<Timer>();

        homeButton.onClick.AddListener(ReturnHome);
    }

    private void Update()
    {
        timerSlider.value = time.localTime;
    }

    private void ReturnHome()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ChangeHealthValue()
    {
        healthBars[healthIndex].SetActive(false);

        healthIndex++;
    }
}
