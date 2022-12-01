using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockPlay : MonoBehaviour
{
    public bool isFlag;
    bool isClick;
    GameObject Flag;
    private void Start()
    {
        isFlag = false;
        isClick = false;
        Flag = Resources.Load("Flag") as GameObject;
    }

    void OnMouseOver()
    {
        if (Time.timeScale == 0)
            return;
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(ClickOrHold());
        if (Input.GetMouseButtonDown(1))
            OnMouseDownRight();

    }

    IEnumerator ClickOrHold()
    {
        if (isClick)
            yield break;

        isClick = true;
        yield return new WaitForSeconds(0.1f);
        if (!Input.GetMouseButton(0))
            OnMouseDownLeft();
        else
            OnMouseDownRight();
        isClick = false;
    }

    void OnMouseDownLeft()
    {
        if (isFlag)
            return;
        float TopLeftI = 0.08f * GamePlayControll.instance.height;
        float TopLeftJ = -0.08f * GamePlayControll.instance.width;
        float posX = transform.position.x;
        float posY = transform.position.y;
        int indexI = Mathf.RoundToInt((TopLeftI - posY) / 0.16f);
        int indexJ = Mathf.RoundToInt((posX - TopLeftJ) / 0.16f);
        SoundManager.instance.PlayClickSound();
        GamePlayControll.instance.ClickOnPlay(indexI, indexJ);
        gameObject.SetActive(false);
    }

    void OnMouseDownRight()
    {
        SoundManager.instance.PlayClickSound();
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
