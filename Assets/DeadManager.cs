using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadManager : MonoBehaviour
{
    public static DeadManager instance;
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
    }

    public void Win()
    {
        Time.timeScale = 0;
        StartCoroutine(ChangeIsUpdate());
    }

    IEnumerator ChangeIsUpdate()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        isUpdate = true;
    }
}
