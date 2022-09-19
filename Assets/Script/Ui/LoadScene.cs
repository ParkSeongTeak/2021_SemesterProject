using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                  //Scene이동 등을 위한 함수와 클래스정의

public class LoadScene : MonoBehaviour
{
    string exitScene = "StartScene";
    string menuScene = "Game";
    public void ToMenuScene()                       //함수는 잘 만들었습니다 하지만 이것만 만들고 버튼 열심히 눌러봐야 아무일도 안일어납니다
                                                    //툴바에 File -> Build Settings -> (추가하고싶은 Scene에 들어가서)Add Open Scenes를 클릭해준 후에야 이 함수가 동작합니다.
                                                    //이같이 코딩에 전혀 문제가 없음에도 버그가 나고 이것저것 해봐도 버그가 안고처진다면 물어봅시다 누구씨는 물어보면 15초면 해결할껄 쪽팔려서 2일간 고생했다고 합니다. 
                                                    //물론 이것저것까지는 해봅시다 ㅎㅎ;;
                                                    //Button 만드는법 툴바 GameObject -> UI -> Button
    {
        GameManager.instance.GameOver = false;
        GameManager.instance.gameStop = false;
        SceneManager.LoadScene(menuScene);
        Time.timeScale = 1;
    }

    public void ToExitScene()
    {
        GameManager.instance.Get_Point = 0;
        GameManager.instance.firstHeight = 0;


        GameManager.instance.GameOver = false;
        GameManager.instance.gameStop = false;
        SceneManager.LoadScene(exitScene);
        Time.timeScale = 1;

        Application.Quit();
    }


}
