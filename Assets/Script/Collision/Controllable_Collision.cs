using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controllable_Collision : MonoBehaviour
{
    GameObject PointText;
    GameObject GameOver;
    const float Dtime = 0.5f;
    float timer = 0.0f;
    Vector3 current;
    Vector3 now;
    bool Physics = true;
    bool currentcheck = false;


    float fortest = 1f;
    private void Awake()
    {   
        GameOver = GameObject.Find("EventSystem");
        PointText = GameObject.Find("Point");
    }
    
    private void Update()
    {
        float FirstHeight = GameManager.instance.firstHeight;
        if (this.Physics)
        {
            if(this.transform.position.y < FirstHeight - 25 * fortest)
            {
                if (!this.currentcheck)
                {
                    current = this.transform.position;
                    this.currentcheck = true;
                }
                timer += Time.deltaTime;
                if (timer >= Dtime)
                {
                    this.currentcheck = false;
                    timer = 0.0f;
                    if (current.y < this.transform.position.y + 0.5f && current.y > this.transform.position.y - 0.5f && current.x> this.transform.position.x - 0.5f && current.x < this.transform.position.x + 0.5f)
                    {

                        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                        this.Physics = false;
                    }

                }

                
                if(this.transform.position.y < FirstHeight - 85*fortest)
                {
                    if (!GameManager.instance.Is_Fever)
                    {
                        GameOver.GetComponent<gameOver>().Gameover();
                    }
                    else
                    {
                        Destroy(this.gameObject);
                        GameManager.instance.FeverMissCount += 1;
                        if (GameManager.instance.FeverMissCount >= 3)
                        {
                            GameManager.instance.FeverEnd();
                        }
                    }
                }

            }

        }
        else
        {
            if (this.transform.position.y < GameManager.instance.firstHeight - 75 * fortest)
            {
                Destroy(this.gameObject);
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
                if (col.gameObject.tag == "First" || col.gameObject.tag == "Second")
                {
                    col.gameObject.tag = "Second";
                    this.gameObject.tag = "First";
                    GameManager.instance.Get_Point++;
                    PointText.GetComponent<ShowPoint>().Print_Text();
                    GameManager.instance.firstHeight = this.gameObject.transform.position.y;
                    
                }

                if(GameManager.instance.Get_Point == 5)
                {
                    GameManager.instance.FeverStart();
                }
                if(GameManager.instance.Get_Point != 0 && GameManager.instance.Get_Point % 100 == 0)
                {
                    GameManager.instance.FeverStart();
                }

                
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
                

            }
        }
    }
    
}
