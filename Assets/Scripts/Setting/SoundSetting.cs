using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    Slider musicSlider;
    Slider soundSlider;

    private void Start()
    {
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        soundSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
        musicSlider.value = SoundManager.instance.musicMul;
        soundSlider.value = SoundManager.instance.soundMul;
    }

    public void SetMusic()
    {
        SoundManager.instance.SetMusic(musicSlider.value);
    }

    public void SetSound()
    {
        SoundManager.instance.SetSound(soundSlider.value);
    }
}
