using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource LoseSound;
    [SerializeField]
    private AudioSource WinSound;
    [SerializeField]
    private AudioSource ClickSound;
    [SerializeField]
    private AudioSource BgSound;
    [SerializeField]
    private AudioSource ButtonClickSound;

    private float bgSoundVolume;
    private float loseSoundVolume;
    private float winSoundVolume;
    private float clickSoundVolume;
    private float buttonClickSoundVolume;

    private float musicMul;
    private float soundMul;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        bgSoundVolume = 0.075f;
        loseSoundVolume = 0.2f;
        winSoundVolume = 0.4f;
        clickSoundVolume = 0.075f;
        buttonClickSoundVolume = 0.5f;
        musicMul = 1f;
        soundMul = 1f;
    }

    public void PlayLoseSound()
    {
        LoseSound.Play();
    }

    public void PlayWinSound()
    {
        WinSound.Play();
    }

    public void PlayClickSound()
    {
        ClickSound.Play();
    }

    public void PlayButtonClickSound()
    {
        ButtonClickSound.Play();
    }

    public void SetMusic(float mul)
    {
        musicMul = mul;
        BgSound.volume = bgSoundVolume * musicMul;
    }

    public void SetSound(float mul)
    {
        soundMul = mul;
        LoseSound.volume = loseSoundVolume * soundMul;
        WinSound.volume = winSoundVolume * soundMul;
        ClickSound.volume = clickSoundVolume * soundMul;
        ButtonClickSound.volume = buttonClickSoundVolume * soundMul;
    }
}
