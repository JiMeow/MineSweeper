using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    float TopLeftI;
    float TopLeftJ;
    void Start()
    {
        TopLeftI = 0.08f * GamePlayControll.instance.height;
        TopLeftJ = -0.08f * GamePlayControll.instance.width;
    }
    public GameObject SpawnBombGameObjects(int bomb, int indexI, int indexJ, bool scripts = false)
    {
        string bombName;
        if (bomb == -1)
            bombName = "Bomb";
        else
            bombName = "MineSweep" + bomb;

        GameObject bombGameObject = Resources.Load(bombName) as GameObject;
        float posX = TopLeftJ + indexJ * 0.16f;
        float posY = TopLeftI - indexI * 0.16f;
        Vector3 pos = new Vector3(posX, posY, 0);
        GameObject newBomb = Instantiate(bombGameObject, pos, Quaternion.identity);

        if (scripts)
        {
            newBomb.AddComponent<Block>();
            newBomb.AddComponent<BoxCollider2D>();
        }
        else if (bomb == 0)
        {
            newBomb.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

        return newBomb;
    }
}
