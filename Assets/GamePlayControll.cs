using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayControll : MonoBehaviour
{
    public static GamePlayControll instance;
    public int flagLeft;
    SpawnManager spawnManager;


    private void Awake()
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

    private void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
        flagLeft = 15;
    }

    private void Update()
    {
        CheckIsWin();
    }

    public void ClickOn(int i, int j)
    {
        int[,] visit = new int[10, 10];
        Show(i, j);
        Dfs(i, j, visit);
    }

    void Dfs(int i, int j, int[,] visit)
    {
        if (i < 0 || i >= 10 || j < 0 || j >= 10)
        {
            return;
        }
        if (visit[i, j] == 1)
        {
            return;
        }
        visit[i, j] = 1;
        if (spawnManager.table[i, j] != 0)
        {
            if (spawnManager.table[i, j] != -1)
            {
                Show(i, j);
            }
            return;
        }
        Show(i, j);

        for (int ii = -1; ii <= 1; ii++)
        {
            for (int jj = -1; jj <= 1; jj++)
            {
                if (ii != 0 | jj != 0)
                    Dfs(i + ii, j + jj, visit);
            }
        }
    }

    void Show(int indexI, int indexJ)
    {
        spawnManager.playTable[indexI, indexJ].SetActive(false);
        spawnManager.tableGameObjects[indexI, indexJ].SetActive(true);
        if (spawnManager.table[indexI, indexJ] == -1)
        {
            DeadManager.instance.Dead();
        }
    }

    void CheckIsWin()
    {
        if (Time.timeScale != 0 & flagLeft == 0)
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (spawnManager.playTable[i, j].activeSelf)
                    {
                        count++;
                    }

                }
            }
            if (count == 15)
            {
                DeadManager.instance.Win();
            }
        }
    }
}
