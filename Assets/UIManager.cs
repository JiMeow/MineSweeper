using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
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
