using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverSystem : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.Fever = this.gameObject;
        GameManager.instance.GameOver = false;
        GameManager.instance.isPause = false;
        Time.timeScale = 1;
    }

    public GameObject FeverBG;
    
    public void FeverStart()
    {
        FeverBG.SetActive(true);
    }
    public void FeverEnd()
    {
        FeverBG.SetActive(false);

    }
   

}
