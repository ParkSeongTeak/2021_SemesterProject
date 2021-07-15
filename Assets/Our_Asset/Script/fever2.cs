using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fever2 : MonoBehaviour
{
    int i = 0;
    float time = 0.5f;
    float timer = 0.5f;

    public GameObject[] Fev = new GameObject[5];
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer = 0.0f;

            for (int j = 0; j < 5; j++)
                Fev[j].SetActive(false);

            Fev[i].SetActive(true);
            i++;
            if (i == 5)
                i = 0;
        }

    }
}
