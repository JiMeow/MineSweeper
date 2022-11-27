using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayControll : MonoBehaviour
{
    public static GamePlayControll instance;
    public int flagLeft;
    public int height;
    public int width;
    public int bombCount;

    SpawnManager spawnManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
        flagLeft = bombCount;
        Time.timeScale = 1;
    }

    private void Update()
    {
        CheckIsWin();
    }

    public void ClickOnPlay(int i, int j)
    {
        int[,] visit = new int[height, width];
        ShowBlock(i, j);
        DfsPlay(i, j, visit);
    }

    void ShowBlock(int indexI, int indexJ)
    {
        spawnManager.playTable[indexI, indexJ].SetActive(false);
        spawnManager.tableGameObjects[indexI, indexJ].SetActive(true);
        if (spawnManager.table[indexI, indexJ] == -1)
            EndGameManager.instance.Dead();
    }
    void DfsPlay(int i, int j, int[,] visit)
    {
        if (i < 0 || i >= height || j < 0 || j >= width)
            return;
        if (visit[i, j] == 1)
            return;
        visit[i, j] = 1;
        if (spawnManager.table[i, j] != 0)
        {
            if (spawnManager.table[i, j] != -1)
                ShowBlock(i, j);
            return;
        }
        ShowBlock(i, j);
        for (int ii = -1; ii <= 1; ii++)
            for (int jj = -1; jj <= 1; jj++)
                if (ii != 0 || jj != 0)
                    DfsPlay(i + ii, j + jj, visit);
    }

    public void ClickOnReal(int i, int j)
    {
        int count = 0;
        for (int ii = -1; ii <= 1; ii++)
            for (int jj = -1; jj <= 1; jj++)
                if (ii != 0 || jj != 0)
                    if (i + ii >= 0 && i + ii < height && j + jj >= 0 && j + jj < width)
                        if (spawnManager.playTable[i + ii, j + jj].activeSelf && spawnManager.playTable[i + ii, j + jj].GetComponent<BlockPlay>().isFlag)
                            count++;
        if (count == spawnManager.table[i, j])
            for (int ii = -1; ii <= 1; ii++)
                for (int jj = -1; jj <= 1; jj++)
                    if (ii != 0 || jj != 0)
                        if (i + ii >= 0 && i + ii < height && j + jj >= 0 && j + jj < width)
                            if (spawnManager.playTable[i + ii, j + jj].activeSelf && !spawnManager.playTable[i + ii, j + jj].GetComponent<BlockPlay>().isFlag)
                                ClickOnPlay(i + ii, j + jj);
    }

    void CheckIsWin()
    {
        if (Time.timeScale != 0 & flagLeft == 0)
        {
            int count = 0;
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (spawnManager.playTable[i, j].activeSelf)
                        count++;

            if (count == bombCount)
                EndGameManager.instance.Win();
        }
    }




}
