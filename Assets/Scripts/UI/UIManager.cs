using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject InputFieldName;
    GameObject winUi;
    GameObject loseUi;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        winUi = GameObject.Find("WinUI");
        winUi.SetActive(false);
        loseUi = GameObject.Find("LoseUI");
        loseUi.SetActive(false);
    }
    public void Win()
    {
        winUi.SetActive(true);
    }

    public void Lose()
    {
        loseUi.SetActive(true);
    }

    public void SavePlayerData()
    {
        string name = InputFieldName.GetComponent<TMP_InputField>().text;
        if (name == "")
            name = "anonymous";
        float datatime = PlayerPrefs.GetFloat(name);
        if (datatime == 0)
            PlayerPrefs.SetFloat(name, Time.timeSinceLevelLoad);
        else
        {
            if (datatime > Time.timeSinceLevelLoad)
                PlayerPrefs.SetFloat(name, Time.timeSinceLevelLoad);
        }

        string bestPlayer = PlayerPrefs.GetString("highScore", "");
        if (bestPlayer == "")
        {
            PlayerPrefs.SetString("highScore", name);
        }
        else
        {
            float bestTime = PlayerPrefs.GetFloat(bestPlayer);
            if (bestTime > Time.timeSinceLevelLoad)
            {
                PlayerPrefs.SetString("highScore", name);
            }
        }
        RestartScene();
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
