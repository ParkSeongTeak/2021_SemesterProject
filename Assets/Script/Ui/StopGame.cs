using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    //public GameObject GameOverImg;
    public GameObject GameStopImg;
    GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = GameObject.Find("EventSystem");

    }

    public void GameStop()
    {
        Time.timeScale = 0;
        GameManager.instance.gameStop = true;
        GameStopImg.SetActive(true);
        return;

    }
    public void GameResume()
    {
        Time.timeScale = 1;
        GameManager.instance.gameStop = false;
        //GameOverImg.SetActive(false);
        GameStopImg.SetActive(false);
        return;
    }


    public void ExitGame()
    {
        GameOver.GetComponent<gameOver>().Gameover();

        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1;


        Application.Quit();
    }
    // Update is called once per frame

}
