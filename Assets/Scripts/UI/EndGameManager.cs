using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;

    SpawnManager spawnManager;
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
        spawnManager = GetComponent<SpawnManager>();
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
        StartCoroutine(BombBomb());
    }

    public void Win()
    {
        Time.timeScale = 0;
        SoundManager.instance.PlayWinSound();
        UIManager.instance.Win();
    }

    IEnumerator ChangeIsUpdate()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        isUpdate = true;
    }

    IEnumerator BombBomb()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SoundManager.instance.PlayLoseSound();
        foreach (GameObject playTable in spawnManager.playTable)
        {
            playTable.SetActive(false);
        }
        foreach (GameObject block in spawnManager.tableGameObjects)
        {
            block.SetActive(true);
        }
        yield return new WaitForSecondsRealtime(0.5f);
        SoundManager.instance.PlayLoseSound();
        foreach (GameObject block in spawnManager.tableGameObjects)
        {
            if (block.transform.name == "Bomb(Clone)")
            {
                block.SetActive(true);
                block.transform.GetChild(0).gameObject.SetActive(false);
                block.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        yield return new WaitForSecondsRealtime(0.5f);
        SoundManager.instance.PlayLoseSound();
        foreach (GameObject block in spawnManager.tableGameObjects)
        {
            if (block.transform.name == "Bomb(Clone)")
            {
                block.SetActive(true);
                block.transform.GetChild(1).gameObject.SetActive(false);
                block.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        yield return new WaitForSecondsRealtime(0.5f);
        StartCoroutine(ChangeIsUpdate());
        UIManager.instance.Lose();
    }
}
