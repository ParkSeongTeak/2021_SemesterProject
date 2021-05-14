using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twins_Collision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        //함수가 한번에 2번 실행되는지 확인하는 함수입니다. 만일 OnCollisionEnter2D함수가 1회 실행되었다면 1회 함수를 무시합니다.
        if (GameManager.instance.IsFuncTwice == true)
        {
            GameManager.instance.IsFuncTwice = false;
        }

        else
        {
            //충돌체의 태그가 First일때, 충돌체의 태그를 Second로 바꾸며 Twins_Count를 1 추가합니다.
            if (col.gameObject.tag == "First")
            {
                col.gameObject.tag = "Second";
                GameManager.instance.Twins_Count++;
                GameManager.instance.IsFuncTwice = true;

                
            }

            //충돌체의 태그가 First일때, 충돌체의 태그를 Second로 바꾸며 Twins_Count를 1 추가합니다.
            if (col.gameObject.tag == "Twins")
            {
                GameManager.instance.Twins_Count++;
            }

            //side tag를 가진 물체와 충돌할 시 게임오버값을 true로 바꿉니다.
            else if (col.gameObject.tag == "Side")
            {
                GameManager.instance.GameOver = true;
            }

            //twins_Count가 2가 되면 2포인트를 얻고 0으로 초기화합니다.
            if (GameManager.instance.Twins_Count == 2)
            {
                GameManager.instance.Get_Point += 2;
                GameManager.instance.Twins_Count = 0;

                GameObject[] Twins_Cubes;
                Twins_Cubes = GameObject.FindGameObjectsWithTag("Twins");
                Twins_Cubes[0].gameObject.tag = "First";
                Twins_Cubes[1].gameObject.tag = "First";

                if (GameManager.instance.firstHeight == 0) // firstHeight값이 0이라면 position.y의 값을 넣어줌
                {
                    GameManager.instance.firstHeight = this.gameObject.transform.position.y;
                }
                else // firstHeight값이 있고 그 값이 position.y 값보다 작다면 position.y값으로 바꿔줌->만약 새로운 블록이 기존 firstHeight보다 작다면 값이 변하지 않음
                {
                    if (GameManager.instance.firstHeight < this.gameObject.transform.position.y) GameManager.instance.firstHeight = this.gameObject.transform.position.y;
                }
            }
        }
    }
}
