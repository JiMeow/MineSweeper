using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockReal : MonoBehaviour
{
    /*
    void OnMouseOver()
    {
        if (Time.timeScale == 0)
            return;
        if (Input.GetMouseButtonDown(0))
            OnMouseDownLeft();
    }

    void OnMouseDownLeft()
    {
        float TopLeftI = 0.08f * GamePlayControll.instance.height;
        float TopLeftJ = -0.08f * GamePlayControll.instance.width;
        float posX = transform.position.x;
        float posY = transform.position.y;
        int indexI = Mathf.RoundToInt((TopLeftI - posY) / 0.16f);
        int indexJ = Mathf.RoundToInt((posX - TopLeftJ) / 0.16f);
        GamePlayControll.instance.ClickOnReal(indexI, indexJ);
    }
    */

    void OnMouseDown()
    {
        float TopLeftI = 0.08f * GamePlayControll.instance.height;
        float TopLeftJ = -0.08f * GamePlayControll.instance.width;
        float posX = transform.position.x;
        float posY = transform.position.y;
        int indexI = Mathf.RoundToInt((TopLeftI - posY) / 0.16f);
        int indexJ = Mathf.RoundToInt((posX - TopLeftJ) / 0.16f);
        GamePlayControll.instance.ClickOnReal(indexI, indexJ);
    }
}
