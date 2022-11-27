using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int[,] table;
    public GameObject[,] tableGameObjects;
    public GameObject[,] playTable;
    int[,] isBombTable;
    SpawnResources spwanGameObjectsResource;
    void Start()
    {
        spwanGameObjectsResource = GetComponent<SpawnResources>();
        table = new int[10, 10];
        isBombTable = new int[10, 10];
        tableGameObjects = new GameObject[10, 10];
        playTable = new GameObject[10, 10];
        SelectBomb();
        SetTable();
        SpawmBomb();
    }

    private void SpawmBomb()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject bomb = spwanGameObjectsResource.SpawnBombGameObjects(table[i, j], i, j);
                tableGameObjects[i, j] = bomb;
                bomb.SetActive(false);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject bomb = spwanGameObjectsResource.SpawnBombGameObjects(0, i, j, scripts: true);
                playTable[i, j] = bomb;
            }
        }
    }

    private void SelectBomb()
    {
        int[] test = new int[100];
        for (int i = 0; i < 100; i++)
        {
            test[i] = i;
        }
        //shulffle test
        for (int i = 0; i < 100; i++)
        {
            int newIndex = Random.Range(0, 100);
            int temp = test[i];
            test[i] = test[newIndex];
            test[newIndex] = temp;
        }
        for (int i = 0; i < 15; i++)
        {
            int x = test[i] / 10;
            int y = test[i] % 10;
            isBombTable[x, y] = 1;
        }

    }

    private void SetTable()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (isBombTable[i, j] == 1)
                {
                    table[i, j] = -1;
                    continue;
                }
                int count = 0;
                if (i > 0 && j > 0 && isBombTable[i - 1, j - 1] == 1)
                    count++;
                if (i > 0 && isBombTable[i - 1, j] == 1)
                    count++;
                if (i > 0 && j < 9 && isBombTable[i - 1, j + 1] == 1)
                    count++;
                if (j > 0 && isBombTable[i, j - 1] == 1)
                    count++;
                if (j < 9 && isBombTable[i, j + 1] == 1)
                    count++;
                if (i < 9 && j > 0 && isBombTable[i + 1, j - 1] == 1)
                    count++;
                if (i < 9 && isBombTable[i + 1, j] == 1)
                    count++;
                if (i < 9 && j < 9 && isBombTable[i + 1, j + 1] == 1)
                    count++;
                table[i, j] = count;
            }
        }
    }
}
