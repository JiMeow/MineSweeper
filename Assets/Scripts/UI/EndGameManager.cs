using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;
    bool isUpdate;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isUpdate = false;
    }

    private void Update()
    {
        if (isUpdate)
        {
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void Dead()
    {
        Time.timeScale = 0;
        StartCoroutine(ChangeIsUpdate());
        UIManager.instance.Lose();
    }

    public void Win()
    {
        Time.timeScale = 0;
        UIManager.instance.Win();
    }

    IEnumerator ChangeIsUpdate()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        isUpdate = true;
    }
}
