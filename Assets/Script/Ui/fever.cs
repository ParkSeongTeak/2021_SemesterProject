using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fever : MonoBehaviour
{
    GameObject[] FeverBG;
    const int bgImgNum = 5;
    const float NeedTime = 0.3f;    // 한번 바뀔 시간
    float timer = 0f;
    int idx = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.Fever = this.gameObject;

        FeverBG = new GameObject[bgImgNum];
        for (int i = 0; i < bgImgNum; i++)
        {
            FeverBG[i] = transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < bgImgNum; i++)
        {
            FeverBG[i].SetActive(false);
        }
        FeverBG[idx].SetActive(true);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= NeedTime)
        {
            timer = 0f;
            FeverBG[idx].SetActive(false);
            idx++;
            if (idx >= bgImgNum)
            {
                idx = 0;
            }
            FeverBG[idx].SetActive(true);

        }

    }
}
