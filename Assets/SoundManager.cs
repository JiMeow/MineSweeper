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
}
