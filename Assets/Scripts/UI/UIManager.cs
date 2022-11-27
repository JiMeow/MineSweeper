using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameObject winUi;
    private void Start()
    {
        winUi = GameObject.Find("WinUI");
        winUi.SetActive(false);
    }
    void Update()
    {
        if (transform.name == "FlagLeft")
        {
            GetComponent<TextMeshProUGUI>().text = GamePlayControll.instance.flagLeft.ToString();
        }
        else if (transform.name == "Time")
        {
            GetComponent<TextMeshProUGUI>().text = "Time: " + (int)Time.timeSinceLevelLoad;
        }
    }

    public void Win()
    {
        winUi.SetActive(true);
    }
}
