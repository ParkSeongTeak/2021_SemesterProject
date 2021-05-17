using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class gameOver : MonoBehaviour
{
    
    public GameObject GameOverImg;
    public GameObject GameOverImg_New_Record;

    public void Gameover()
    {
        
        GameManager.instance.GameOver = true;
        GameOverImg.SetActive(true);
        if (GameManager.instance.Get_Point > GameManager.instance.Get_Max_Point())
        {
            GameManager.instance.SaveData();
            GameOverImg_New_Record.SetActive(true);
        }
        
    }
    public void ReStart()
    {
        GameManager.instance.Get_Point = 0;
        GameManager.instance.firstHeight = 0;
        GameManager.instance.GameOver = false;
        SceneManager.LoadScene("Game");
    }
}
