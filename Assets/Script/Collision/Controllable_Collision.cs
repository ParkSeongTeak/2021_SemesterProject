﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controllable_Collision : MonoBehaviour
{
    GameObject PointText;
    
    bool Physics = true;
    bool Move = true;
    private void Awake()
    {

        PointText = GameObject.Find("Point");
    }
    
    private void Update()
    {
        if (this.Physics)
        {
            if(this.transform.position.y <  GameManager.instance.firstHeight - 60)
            {

                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                this.Physics = false;
            }

        }   
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (this.gameObject.tag == "Controllable")
        {
            //피버상태가 아닐때의 함수들입니다.
            if (GameManager.instance.Is_Fever == false)
            {
                //충돌체의 태그가 First일때, 각 태그가 First, Second로 바뀌며 점수를 획득합니다.
                if (col.gameObject.tag == "First")
                {
                    col.gameObject.tag = "Second";
                    this.gameObject.tag = "First";
                    GameManager.instance.Get_Point++;
                    PointText.GetComponent<ShowPoint>().Print_Text();
                    GameManager.instance.firstHeight = this.gameObject.transform.position.y;
                    
                }

                //충돌체의 태그가 Second일때,  각 태그가 First, Second로 바뀌며 점수를 획득하지 않습니다.
                else if (col.gameObject.tag == "Second")
                {
                    col.gameObject.tag = "Second";
                    this.gameObject.tag = "First";
                }

                //side tag를 가진 물체와 충돌할 시 게임오버값을 true로 바꿉니다.
                else if (col.gameObject.tag == "Side")
                {
                    GameManager.instance.GameOver = true;
                }
            }

            //피버상태일때의 함수입니다.
            else
            {
                //충돌체의 태그가 First일때, 각 태그가 First, Second로 바뀌며 점수를 획득합니다.
                if (col.gameObject.tag == "First")
                {
                    col.gameObject.tag = "Second";
                    this.gameObject.tag = "First";
                    GameManager.instance.Get_Point++;
                }

                //충돌체의 태그가 Second일때,  각 태그가 First, Second로 바뀌며 점수를 획득하지 않습니다.
                else if (col.gameObject.tag == "Second")
                {
                    col.gameObject.tag = "Second";
                    this.gameObject.tag = "First";
                }
            }
        }
    }
    
}
