using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager audioInstance;

    [SerializeField] private AudioSource _bgmSource;

    private void Awake()
    {
        if (audioInstance == null)
        {
            audioInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        _bgmSource.mute = !ConfigData.configInstance.isBgmOn;
    }
}
