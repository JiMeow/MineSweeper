using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    public float TopLeftI = 0.8f;
    public float TopLeftJ = -0.8f;
    public GameObject SpawnBombGameObjects(int bomb, int indexI, int indexJ, bool scripts = false)
    {
        string bombName;
        if (bomb != -1)
            bombName = "MineSweep" + bomb;
        else
            bombName = "Bomb";

        GameObject bombGameObject = Resources.Load(bombName) as GameObject;
        float posX = TopLeftJ + indexJ * 0.16f;
        float posY = TopLeftI - indexI * 0.16f;
        Vector3 pos = new Vector3(posX, posY, 0);
        GameObject newBomb = Instantiate(bombGameObject, pos, Quaternion.identity);

        if (scripts)
        {
            newBomb.AddComponent<BombClickOn>();
            newBomb.AddComponent<BoxCollider2D>();
        }
        else if (bomb == 0)
        {
            newBomb.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

        return newBomb;
    }
}
