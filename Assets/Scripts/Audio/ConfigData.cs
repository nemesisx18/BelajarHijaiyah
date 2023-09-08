using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigData : MonoBehaviour
{
    public static ConfigData configInstance;

    public bool isBgmOn { get; private set; }

    private void OnEnable()
    {
        LoadData();
    }

    private void Awake()
    {
        if (configInstance == null)
        {
            configInstance = this;
            Debug.Log(configInstance);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ToggleMusic()
    {
        isBgmOn = !isBgmOn;
        if (isBgmOn)
        {
            PlayerPrefs.SetInt("BGM", 1); //BGM on
        }
        else
        {
            PlayerPrefs.SetInt("BGM", 0); //BGM off
        }
        PlayerPrefs.Save();
        Debug.Log("BGM status: " + isBgmOn);
    }

    private void LoadData()
    {
        int bgmDataHolder = PlayerPrefs.GetInt("BGM");
        if (bgmDataHolder == 1)
        {
            isBgmOn = true;
        }
        else
        {
            isBgmOn = false;
        }
    }
}
