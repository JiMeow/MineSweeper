using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchScoreboard : MonoBehaviour
{
    TMP_Text nameText;
    TMP_Text scoreText;
    TMP_InputField inputField;

    private void Start()
    {
        nameText = GameObject.Find("name").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("score").GetComponent<TMP_Text>();
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
    }

    public void Search()
    {
        string input = inputField.text;
        input = input.ToLower();
        float score = PlayerPrefs.GetFloat(input, -1);
        if (score == -1)
        {
            nameText.text = "Not Found";
            scoreText.text = "Not Found";
        }
        else
        {
            nameText.text = input;
            scoreText.text = score.ToString() + " seconds";
        }
    }

    public void Clear()
    {
        nameText.text = "";
        scoreText.text = "";
    }
}
