using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject selectModePanel;

    [Header("Info Panel")]
    [SerializeField] private Button infoButton;
    [SerializeField] private Button closeInfoButton;

    [SerializeField] private GameObject infoPanel;

    [Header("Exit Panel")]
    [SerializeField] private Button exitButton;
    [SerializeField] private Button cancelExitButton;
    [SerializeField] private Button confirmExitButton;

    [SerializeField] private GameObject exitPanel;

    [Header("Setting Panel")]
    [SerializeField] private Button settingButton;
    [SerializeField] private Button closeSettingButton;

    [SerializeField] private GameObject settingPanel;

    [Header("Select Mode Menu")]
    [SerializeField] private GameObject panelModeTebak;
    [SerializeField] private GameObject panelModePuzzle;
    [SerializeField] private GameObject panelModeTulis;

    [SerializeField] private Button[] menuModeButton;
    [SerializeField] private Button selectModeTebak;
    [SerializeField] private Button selectModePuzzle;
    [SerializeField] private Button selectModeTulis;
    [SerializeField] private Button playModeTebakButton;
    [SerializeField] private Button playModePuzzleButton;
    [SerializeField] private Button playModeTulisButton;

    [Header("Audio settings")]
    [SerializeField] private Button audioOnButton;
    [SerializeField] private Button audioOffButton;

    private bool isActive;

    private void Start()
    {
        playButton.onClick.AddListener(ToggleModePanel);

        infoButton.onClick.AddListener(ToggleInfoPanel);
        closeInfoButton.onClick.AddListener(ToggleInfoPanel);

        exitButton.onClick.AddListener(ToggleExitPanel);
        cancelExitButton.onClick.AddListener(ToggleExitPanel);
        confirmExitButton.onClick.AddListener(ExitGame);

        settingButton.onClick.AddListener(ToggleSettingPanel);
        audioOnButton.onClick.AddListener(ToggleAudioSetting);
        audioOffButton.onClick.AddListener(ToggleAudioSetting);
        closeSettingButton.onClick.AddListener(ToggleSettingPanel);

        for (int i = 0; i < menuModeButton.Length; i++)
        {
            menuModeButton[i].onClick.AddListener(BackToMenu);
        }
        selectModeTebak.onClick.AddListener(ToggleModeTebak);
        selectModePuzzle.onClick.AddListener(ToggleModePuzzle);
        selectModeTulis.onClick.AddListener(ToggleModeTulis);
        playModeTebakButton.onClick.AddListener(LoadTebakScene);
        playModePuzzleButton.onClick.AddListener(LoadPuzzleScene);
        playModeTulisButton.onClick.AddListener(LoadTulisScene);
    }

    private void Update()
    {
        if(ConfigData.configInstance.isBgmOn)
        {
            audioOnButton.interactable = false;
            audioOffButton.interactable = true;
        }
        else
        {
            audioOnButton.interactable= true;
            audioOffButton.interactable = false;
        }
    }

    private void ToggleModePanel()
    {
        ToggleGameObject(selectModePanel);
    }

    private void ToggleInfoPanel()
    {
        ToggleGameObject(infoPanel);
    }

    private void ToggleExitPanel()
    {
        ToggleGameObject(exitPanel);
    }

    private void ToggleSettingPanel()
    {
        ToggleGameObject(settingPanel);
    }

    private void ToggleModeTebak()
    {
        ToggleGameObject(panelModeTebak);
    }

    private void ToggleModePuzzle()
    {
        ToggleGameObject(panelModePuzzle);
    }

    private void ToggleModeTulis()
    {
        ToggleGameObject(panelModeTulis);
    }

    private void ToggleGameObject(GameObject panel)
    {
        isActive = panel.activeSelf;

        isActive = !isActive;

        switch (isActive)
        {
            case true:
                panel.SetActive(isActive);
                break;
            case false:
                panel.SetActive(isActive);
                break;
        }
    }

    private void ToggleAudioSetting()
    {
        ConfigData.configInstance.ToggleMusic();
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void BackToMenu()
    {
        LoadScene("Menu");
    }

    private void LoadTebakScene()
    {
        LoadScene("TebakHijaiyah");
    }

    private void LoadPuzzleScene()
    {
        LoadScene("PuzzleHijaiyah");
    }

    private void LoadTulisScene()
    {
        LoadScene("TulisHijaiyah");
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }    
}
