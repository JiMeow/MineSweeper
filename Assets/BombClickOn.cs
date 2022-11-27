using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombClickOn : MonoBehaviour
{
    public bool isFlag;
    GameObject Flag;
    private void Start()
    {
        isFlag = false;
        Flag = Resources.Load("Flag") as GameObject;
    }

    void OnMouseOver()
    {
        if (Time.timeScale == 0)
            return;
        if (Input.GetMouseButtonDown(0))
            OnMouseDownLeft();
        if (Input.GetMouseButtonDown(1))
            OnMouseDownRight();
    }

    void OnMouseDownLeft()
    {
        if (isFlag)
            return;
        float posX = transform.position.x;
        float posY = transform.position.y;
        int indexI = (int)((0.8f - posY) / 0.16f);
        int indexJ = (int)((posX + 0.8f) / 0.16f);
        GamePlayControll.instance.ClickOn(indexI, indexJ);
        gameObject.SetActive(false);
    }

    void OnMouseDownRight()
    {
        if (!isFlag)
        {
            if (GamePlayControll.instance.flagLeft <= 0)
                return;
            isFlag = true;
            GamePlayControll.instance.flagLeft--;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
            GameObject tempFlag = Instantiate(Flag, pos, Quaternion.identity);
            tempFlag.transform.parent = transform;
        }
        else
        {
            isFlag = false;
            GamePlayControll.instance.flagLeft++;
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
