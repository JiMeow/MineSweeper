using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    GameObject winUi;

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
    }
    public void Win()
    {
        winUi.SetActive(true);
    }
}
