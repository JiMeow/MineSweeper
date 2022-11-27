using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScoreboard : MonoBehaviour
{
    public bool isReset;
    private void Start()
    {
        isReset = false;
    }
    private void Update()
    {
        if (isReset)
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
