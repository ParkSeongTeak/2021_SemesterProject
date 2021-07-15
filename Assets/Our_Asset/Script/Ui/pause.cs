using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public bool IsPause;
    // Start is called before the first frame update
    void Awake()
    {
        IsPause = false;
        GameManager.instance.isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPause)
        {
            Time.timeScale = 0;
            IsPause = true;
            return;
        }
        if (!IsPause)
        {
            Time.timeScale = 1;
            IsPause = false;
            return;
        }
    }
    public void StartPause()
    {
        IsPause = true;
        GameManager.instance.isPause = true;

    }
    public void StopPause()
    {
        IsPause = false;
        GameManager.instance.isPause = false;
    }
}
