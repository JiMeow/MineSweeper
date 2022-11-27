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
    }
}
