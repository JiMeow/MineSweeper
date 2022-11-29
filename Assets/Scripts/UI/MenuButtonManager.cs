using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SoundManager.instance.PlayButtonClickSound();
        StartCoroutine(ChangeScene("Game"));
    }

    public void BackToMenu()
    {
        SoundManager.instance.PlayButtonClickSound();
        StartCoroutine(ChangeScene("Menu"));
    }

    public void Credit()
    {
        SoundManager.instance.PlayButtonClickSound();
        StartCoroutine(ChangeScene("Credit"));
    }

    public void Setting()
    {
        SoundManager.instance.PlayButtonClickSound();
        StartCoroutine(ChangeScene("Setting"));
    }

    public void Scoreboard()
    {
        SoundManager.instance.PlayButtonClickSound();
        StartCoroutine(ChangeScene("Scoreboard"));
    }
    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (sceneName == "Credit")
        {
            Application.OpenURL("https://github.com/JiMeow/MineSweeper");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
