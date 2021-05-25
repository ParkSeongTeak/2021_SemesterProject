using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    public GameObject GameOverImg;
    public GameObject GameStopImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStop()
    {
        if (GameManager.instance.gameStop == false) //게임이 일시정지 상태가 아닐 때
        {
            Time.timeScale = 0;
            GameManager.instance.gameStop = true;
            GameStopImg.SetActive(false);
            return;
        }
        if (GameManager.instance.gameStop == true) //게임이 일시정지 상태일 때
        {
            Time.timeScale = 1;
            GameManager.instance.gameStop = false;
            GameOverImg.SetActive(false);
            GameStopImg.SetActive(true);
            return;
        }
    }

    public void ExitGame()
    {

        SceneManager.LoadScene("StartScene");
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
