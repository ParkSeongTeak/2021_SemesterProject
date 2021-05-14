using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour        //이 클래스는 public 하게 설정되었습니다. 다른 script에서도 이 class를 사용 할 수 있습니다.  
{                                               //모든 script는 기본적으로 public 하게 설정됩니다. 하지만 other script -> GameManager 그리고 GameManager -> other script 만 함수나 변수를 주고받는 것을 
                                                //허용합니다. other script -> Another script 간의 통신을 우리를 모두 죽음으로 내몰 것입니다..... 
                                 
    


    public static GameManager instance;         //이 클래스의 객체입니다. 우리는 이제부터 이 객체를 게임 매니저라고 생각하고 사용할 것입니다.
    
    public bool GameOver = false;               //게임이 오버되었는지 알아보는 부울값입니다.
    public int Get_Point = 0;                   //게임 실행할 때 나타날 포인트입니다.
    public bool Is_Fever = false;               //피버상태인지 알아보는 부울값입니다.
    public int Twins_Count = 0;                 //Twins 큐브가 1번 쌓일때마다 1씩 증가하며 count가 2가 되면 2포인트를 획득합니다.
    public bool IsFuncTwice = false;


    public float firstHeight = 0; // first큐브 y값 입니다.


    private void Awake()                        //Scene 이동을 하더라도 이 객체는 부서지지 않습니다. Scene 이동을 통해 어떤 식으로 객체가 부서지지 않는지 확인해봅시다. 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);        
        }
        
    }

    public void SaveData()                                      //변수 저장 방법입니다.
    {                                                           //other script에서 불러봅시다.
    }
    public void GetDate()                                       //저장한 변수를 불러오는 방법입니다.
    {
    }

}