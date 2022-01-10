using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controllable_Collision : MonoBehaviour
{
    GameObject PointText;
    GameObject GameOver;
    public GameObject FeverEffect;

    const float Dtime = 0.5f;
    float timer = 0.0f;
    Vector3 current;
    Vector3 now;
    Vector3 FeverEffectCorrentionLeft = new Vector3(-3, 0, 0);
    Vector3 FeverEffectCorrentionRight = new Vector3(+3, 0 , 0);

    bool Physics = true;
    bool currentcheck = false;

    bool FeverEnd = false;
    //float R, G, B;
    bool Rup , Gup , Bup;
    SpriteRenderer spr;
    Color color;


    float fortest = 1f;
    private void Awake()
    {   
        GameOver = GameObject.Find("EventSystem");
        PointText = GameObject.Find("Point");
    }
    private void Start()
    {
        this.Rup = true;
        this.Gup = true;
        this.Bup = true;
        spr = this.gameObject.GetComponent<SpriteRenderer>();

        //Debug.Log(this.color.r + this.color.g + this.color.b);
        if (GameManager.instance.Is_Fever == true)
        {
            this.color.r = 1.0f;
            this.color.g = 0.5f;
            this.color.b = 0.0f;
            this.color.a = 1.0f; 
        
            spr.color = this.color;
            FeverEnd = true;
        }
        Debug.Log(spr.color.r+ " " + spr.color.g + " " + spr.color.b);
    }
    void SortColor()
    {
        color.r = 1.0f;
        color.g = 1.0f;
        color.b = 1.0f;
        color.a = 1.0f;

        spr.color = this.color;

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
                        this.gameObject.tag = "First";
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

    private void FixedUpdate()
    {
        if(FeverEnd != GameManager.instance.Is_Fever)
        {
            SortColor();
            FeverEnd = GameManager.instance.Is_Fever;
        }

        if(this.gameObject.tag == "Controllable" && GameManager.instance.Is_Fever)
        {

            if (this.Rup)
            {
                this.color.r += 0.02f;
                if (this.color.r >= 0.9f)
                    this.Rup = !this.Rup;
            }
            else 
            {
                this.color.r -= 0.02f;
                if (this.color.r <= 0.1f)
                    this.Rup = !this.Rup;
            }

            if (this.Gup)
            {
                this.color.g += 0.02f;
                if (this.color.g >= 0.9f)
                    this.Gup = !this.Gup;
            }
            else
            {
                this.color.g -= 0.02f;
                if (this.color.g <= 0.1f)
                    this.Gup = !this.Gup;
            }

            if (this.Bup)
            {
                this.color.b += 0.02f;
                if (this.color.b >= 0.9f)
                    this.Bup = !this.Bup;
            }
            else
            {
                this.color.b -= 0.02f;
                if (this.color.b <= 0.1f)
                    this.Bup = !this.Bup;
            }
            spr.color = this.color;

        }
    }

    

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (this.gameObject.tag == "Controllable")
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

            SortColor();
            //피버상태가 아닐때의 함수들입니다.
            if (GameManager.instance.Is_Fever == false)
            {
             
                if(GameManager.instance.Get_Point == 5)
                {
                    GameManager.instance.FeverStart();
                }
                if(GameManager.instance.Get_Point != 0 && GameManager.instance.Get_Point % 100 == 0)
                {
                    GameManager.instance.FeverStart();
                }
                
            }

            //피버상태일때의 함수입니다.
            else
            {
                Instantiate(FeverEffect, transform.position + FeverEffectCorrentionLeft, Quaternion.identity);
                Instantiate(FeverEffect, transform.position + FeverEffectCorrentionRight, Quaternion.identity);

            }
        }
    }
    
}
