using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AllTextUpdate : MonoBehaviour
{
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
        else if (transform.name == "BestTime")
        {
            string bestPlayer = PlayerPrefs.GetString("highScore", "");
            if (bestPlayer == "")
            {
                GetComponent<TextMeshProUGUI>().text = "Best Time: " + "_";
            }
            else
            {
                float bestTime = PlayerPrefs.GetFloat(bestPlayer);
                GetComponent<TextMeshProUGUI>().text = "Best Time: " + (int)bestTime + " seconds (" + bestPlayer + ")";
            }
        }
    }
}
