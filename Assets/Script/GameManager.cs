using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour        //이 클래스는 public 하게 설정되었습니다. 다른 script에서도 이 class를 사용 할 수 있습니다.  
{                                               //모든 script는 기본적으로 public 하게 설정됩니다. 하지만 other script -> GameManager 그리고 GameManager -> other script 만 함수나 변수를 주고받는 것을 
                                                //허용합니다. other script -> Another script 간의 통신을 우리를 모두 죽음으로 내몰 것입니다..... 
                                 
    


    public static GameManager instance;         //이 클래스의 객체입니다. 우리는 이제부터 이 객체를 게임 매니저라고 생각하고 사용할 것입니다.
    public int Publicnum = 0;                   //예를 들어 other script에서 이 num의 값에 1을 더하고 싶다면 GameManager.instance.Publicnum += 1; 이라고 쓰면 게임 매니저 instance 객체의 num값에 1이 더해질 것입니다


    string PrefsPublicnum = "저장하기 위한 string입니다 아래SaveData()에서 어떻게 쓰는지 봅시다";



    private int Privatenum = 0;                 //훠어얼씬 안전하고 좋은 private 변수입니다. private 이 public 보다 좋은 이유는 30개가 넘고 public 이 private보다 좋은 이유는 "편하다" 단 한 가지뿐입니다.
                                                //그래서 저는 public을 주로 씁니다....... 뭐 그냥 private이 더 좋다는건 알아둡시다.

    string PrefsPrivatenum = "저장을 위한 string은 절때 public하게 만들지맙시다...그걸로 3일간 삽질해봤습니다....";

    public void setPrivatenum(int n)            //함수 위에 참조 개수도 표시가 되어있습니다. ?? 안 보이는데요?? 위  GameManager도 청녹색으로 안보이고 그냥 흰색인데요? 하면 그 비주얼 스튜디오 Unity뭐시기가 안 깔린 겁니다  
                                                //그걸 어디서 깔더라.... 아무튼 문의주세요 기억은 잘 안 납니다만 같이 찾아보죠...... 참조 글씨가 있으면 마우스 올리고 어디서 참조 중인지를 한번 봐봅시다 역시 private이 좋긴 합니다.......
    {
        Privatenum = n;
    }                                           //Privatenum에 수를 넣는 public 함수 other script에서 접근 가능 GameManager.instance.setPrivatenum(n);
    public int getPrivatenum()             
    {                                           
        return Privatenum;
    }                                           //Privatenum의 수를 가져오는 public 함수 other script에서 접근가능 GameManager.instance.getPrivatenum();







    private void Awake()                        //Scene 이동을 하더라도 이 객체는 부서지지 않습니다. Scene 이동을 통해 어떤 식으로 객체가 부서지지 않는지 확인해봅시다. 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);        
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()                                      //변수 저장 방법입니다.
    {                                                           //other script에서 불러봅시다.
        PlayerPrefs.SetInt(PrefsPublicnum, Publicnum);          //PlayerPrefs.SetInt( 암호화용string , 저장할 숫자);         //저 문자열에 숫자가 저장되었습니다
        PlayerPrefs.SetInt(PrefsPrivatenum, Privatenum);        //PlayerPrefs.SetInt( 암호화용string , 저장할 숫자); 
    }
    public void GetDate()                                       //저장한 변수를 불러오는 방법입니다.
    {
        Publicnum = PlayerPrefs.GetInt(PrefsPublicnum,0);       //문자열에 저장된 숫자를 가지고옵니다 (Set/Get)Float , (Set/Get)String도 가능합니다
        Privatenum = PlayerPrefs.GetInt(PrefsPrivatenum, 0);    //만약 해당 문자열로 Set한적이 없다면 오른쪽 0을 가져옵니다.
    }

}