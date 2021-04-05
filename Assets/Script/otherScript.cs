using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                           //Text등 UI기능을 사용하기위한 함수와 클래스


//이 Script  Canvas에 붙어놨습니다


public class otherScript : MonoBehaviour        //버튼도 만들고 GameManager.instance 에 있는 함수 번수도 가져와서 이것저것 해봅시다.  MonoBehaviour 기본 함수와 클래스를 상속해주는친구 지우면 클남
{
    int n = 0;
    int num = 0;

    //Text 만드는법 툴바 GameObject -> UI -> Text
    public Text textPublicnum;                           //public 하게 선언해서 inspector창에서 끼워넣을수 있게 만들겁니다. public하게 만들면 드래그엔 드롭으로 쉽게 넣을수 있습니다.
    public Text textPrivatenum;
    public GameObject Object;                   //게임 오브젝트도 여기다 드레그엔 드롭으로 넣어서 사용 할 수 있습니다


    // Start is called before the first frame update
    void Start()                //실행시 위 script가 붙어있는 객체의 active가 켜져있다면 단 한번 돌아갑니다.
    {
        Debug.Log("Console창에 이 글을 출력합니다 "+ GameManager.instance.Publicnum + " 이처럼 + 로 여러 숫자들과 문자열들도 한꺼번에 삽입할수있는 갓 함수입니다. 어디서 함수가 무한랙이 돌고 그런지 확인해볼수있습니다");
    }

    // Update is called once per frame
    void Update()               //초당 60번쯤 돕니다. 여기에 함수가 많이들어가면 들어갈수록 게임이 기하급수적으로 무거워지니 어지간하면 안쓰는 방향으로 갑시다.
    {
        if(n < 600)
        {
            Debug.Log("그래 초당 이만큼이나 돌면 당연히 무거워지겠지....");
            n++;

        }
    }
    
    public void PlusPublicnum()             //버튼을 만들겁니다. public 하게 선언해줍시다
                                            //Button 만드는법 툴바 GameObject -> UI -> Button
    {
        GameManager.instance.Publicnum += 1;        //GameManager에 있는 public 변수를 그대로 가져다 썼습니다.
        //GameManager.instance.Privatenum += 1;     //될 리가 없습니다

        textPublicnum.text = "Publicnum: " + GameManager.instance.Publicnum;




        num++;                                      //본인 함수 내부에서 잠깐쓰고 말꺼아님 변수명 이렇게 만들지 맙시다 num이 뭐에대한 num이라는거야? 
        GameManager.instance.setPrivatenum(num);
        textPrivatenum.text = "Privatenum: " + GameManager.instance.getPrivatenum();

        Object.transform.position = new Vector3(GameManager.instance.Publicnum, 0, 0);


        GameManager.instance.SaveData();
    }

    public void ReSet()
    {
        num = 0;
        GameManager.instance.Publicnum = num;
        GameManager.instance.setPrivatenum(num);
        textPublicnum.text = "Publicnum: " + GameManager.instance.Publicnum;
        textPrivatenum.text = "Privatenum: " + GameManager.instance.getPrivatenum();
        Object.transform.position = new Vector3(GameManager.instance.Publicnum * 5, 0, 0);


        GameManager.instance.SaveData();

    }
}
