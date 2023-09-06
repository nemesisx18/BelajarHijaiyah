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
    [SerializeField] private Button audioOnButton;
    [SerializeField] private Button audioOffButton;
    [SerializeField] private Button closeSettingButton;

    [SerializeField] private GameObject settingPanel;

    [Header("Select Mode Menu")]
    [SerializeField] private Button tebakButton;
    [SerializeField] private Button puzzleButton;
    [SerializeField] private Button tulisButton;

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

        tebakButton.onClick.AddListener(LoadTebakScene);
        puzzleButton.onClick.AddListener(LoadPuzzleScene);
        tulisButton.onClick.AddListener(LoadTulisScene);
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

    }

    private void ExitGame()
    {
        Application.Quit();
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
