using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Credit()
    {
        Application.OpenURL("https://github.com/JiMeow/MineSweeper");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void Scoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }
}
