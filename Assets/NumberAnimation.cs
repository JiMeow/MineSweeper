using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberAnimation : MonoBehaviour
{
    GameObject[] allNumber;
    bool animationReady;
    void Start()
    {
        Transform[] allNumberTemp = GetComponentsInChildren<Transform>();
        allNumber = new GameObject[allNumberTemp.Length - 1];
        for (int i = 0; i < allNumber.Length; i++)
        {
            allNumber[i] = allNumberTemp[i + 1].gameObject;
            allNumber[i].SetActive(false);
        }
        animationReady = true;
    }


    void Update()
    {
        if (animationReady)
        {
            StartCoroutine(numberAppearAnimation());
        }
    }

    IEnumerator numberAppearAnimation()
    {
        animationReady = false;
        Shuffle(allNumber);
        foreach (GameObject number in allNumber)
        {
            StartCoroutine(AppearAndDisappear(number));
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        animationReady = true;
    }

    IEnumerator AppearAndDisappear(GameObject number)
    {
        number.SetActive(true);
        float waitTime = Random.Range(0.5f, 1.0f);
        yield return new WaitForSeconds(waitTime);
        number.SetActive(false);
    }

    void Shuffle(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            GameObject temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
