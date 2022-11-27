using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int[,] table;
    int[,] isBombTable;
    public GameObject[,] tableGameObjects;
    public GameObject[,] playTable;

    SpawnResources spwanGameObjectsResource;
    int height;
    int width;
    void Start()
    {
        height = GamePlayControll.instance.height;
        width = GamePlayControll.instance.width;
        spwanGameObjectsResource = GetComponent<SpawnResources>();

        table = new int[height, width];
        isBombTable = new int[height, width];
        tableGameObjects = new GameObject[height, width];
        playTable = new GameObject[height, width];

        SelectBomb();
        SetTable();
        SpawmBomb();
    }

    private void SpawmBomb()
    {
        //real table
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject bomb = spwanGameObjectsResource.SpawnBombGameObjects(table[i, j], i, j);
                tableGameObjects[i, j] = bomb;
                bomb.SetActive(false);
            }
        }
        //on click table
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject bomb = spwanGameObjectsResource.SpawnBombGameObjects(0, i, j, scripts: true);
                playTable[i, j] = bomb;
            }
        }
    }

    private void SelectBomb()
    {
        int[] test = new int[width * height];
        for (int i = 0; i < width * height; i++)
        {
            test[i] = i;
        }
        //shulffle test
        for (int i = 0; i < width * height; i++)
        {
            int newIndex = Random.Range(0, width * height);
            int temp = test[i];
            test[i] = test[newIndex];
            test[newIndex] = temp;
        }
        for (int i = 0; i < GamePlayControll.instance.bombCount; i++)
        {
            int x = test[i] / width;
            int y = test[i] % width;
            isBombTable[x, y] = 1;
        }

    }

    private void SetTable()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (isBombTable[i, j] == 1)
                {
                    table[i, j] = -1;
                    continue;
                }
                //count bomb
                int count = 0;
                for (int k = -1; k <= 1; k++)
                {
                    for (int l = -1; l <= 1; l++)
                    {
                        if (k == 0 & l == 0)
                            continue;
                        if (i + k < 0 || i + k >= height || j + l < 0 || j + l >= width)
                            continue;
                        if (isBombTable[i + k, j + l] == 1)
                            count++;
                    }
                }
                table[i, j] = count;
            }
        }
    }
}
