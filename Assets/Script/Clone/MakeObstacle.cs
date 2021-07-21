using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
0. 게임중이야?
1. 장애물 나올 거야 말 꺼야? 높이가 넘었어 안 넘었어? 
2. 넘었다면 10초 뒤 생성할 거야 말 거야?
3. 생성할 거면 왼쪽에서 나올 거야 오른쪽에서 나올 거야?
4. 왼쪽 (오른쪽에서) 나올 거면 무슨 장애물이 나올 거야?
5. 무슨 장애물이 나올 거면 어떤 스타팅 포인트에서 나올 거야?
6. 무슨 스타팅 포인트에서 나올 거면 얼마의 힘과 속력으로 나올 거야?
*/


public class MakeObstacle : MonoBehaviour
{

    public GameObject[] LeftPrefabCube;
    public GameObject[] RightPrefabCube;
    public GameObject[] LeftStartPoint;
    public GameObject[] RightStartPoint;

    GameObject Object;
    GameObject MainCamera;

    Vector3 HightVec = new Vector3(0, 550, 0);

    const int RandDenominator = 5;
    //const int RocketRand = 5;
    bool ReadyToMake;
    
    float timer;
    float DelayTime = 10.0f;

    int LeftPrefnum;
    int RightPrefnum;
    int LeftStartPointnum;
    int RightStartPointnum;

    Vector3 ForLeft = new Vector3(1, 0, 0);
    Vector3 ForRight = new Vector3(-1, 0, 0);


    private void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        timer = 0.0f;

        LeftPrefnum = LeftPrefabCube.GetLength(0);
        RightPrefnum = RightPrefabCube.GetLength(0);
        LeftStartPointnum = LeftStartPoint.GetLength(0);
        RightStartPointnum = RightStartPoint.GetLength(0);

        
    }

    void Update()
    {
        if (ReadyToMake)                    //2. 이거 먼저하는게 효율적일꺼같아서
        {
            ReadyToMake = false;
            if (!GameManager.instance.GameOver) //0.
            {

                if(MainCamera.transform.localPosition.y < HightVec.y )//1.
                {
                    if (Random.Range(0, 2) == 1)  //4.왼쪽
                    {
                        int Rand = Random.Range(0, LeftPrefnum);
                        Object = Instantiate(LeftPrefabCube[Rand], LeftStartPoint[LeftStartPointnum-1].transform.position, LeftStartPoint[Random.Range(0, LeftStartPointnum)].transform.rotation);     //5.  //6.
                        Rigidbody2D rigidbody = Object.GetComponent<Rigidbody2D>();
                        if (Rand != 2)                                                                 //로켓 아닐때 == 새일때
                        {
                            rigidbody.AddForce(ForLeft * 40f, ForceMode2D.Impulse);
                        }
                        else                                                                           //로켓일때
                        {
                            rigidbody.AddForce(ForLeft * 80f, ForceMode2D.Impulse);

                        }
                    }
                    else                           //4.오른쪽
                    {
                        int Rand = Random.Range(0, RightPrefnum);

                        Object = Instantiate(RightPrefabCube[Rand], RightStartPoint[Random.Range(0, RightStartPointnum)].transform.position, RightStartPoint[Random.Range(0, RightStartPointnum)].transform.rotation);     //5.  //6.
                        Rigidbody2D rigidbody = Object.GetComponent<Rigidbody2D>();
                        if (Rand != 2)                                                                 //로켓 아닐때 == 새일때
                        {
                            rigidbody.AddForce(ForRight * 40f, ForceMode2D.Impulse);
                        }
                        else                                                                           //로켓일때
                        {
                            rigidbody.AddForce(ForRight * 80f, ForceMode2D.Impulse);

                        }
                    }
                }


                else //1.
                {

                    if (Random.Range(0, 2) == 1)  //4.왼쪽
                    {
                        int Rand = Random.Range(0, LeftPrefnum);
                        Object = Instantiate(LeftPrefabCube[Rand], LeftStartPoint[Random.Range(0, LeftStartPointnum)].transform.position, LeftStartPoint[Random.Range(0, LeftStartPointnum)].transform.rotation);     //5.  //6.
                        Rigidbody2D rigidbody = Object.GetComponent<Rigidbody2D>();
                        if (Rand != 2)                                                                 //로켓 아닐때 == 새일때
                        {
                            rigidbody.AddForce(ForLeft * 40f, ForceMode2D.Impulse);
                        }
                        else                                                                           //로켓일때
                        {
                            rigidbody.AddForce(ForLeft * 80f, ForceMode2D.Impulse);

                        }
                    }
                    else                           //4.오른쪽
                    {
                        int Rand = Random.Range(0, RightPrefnum);

                        Object = Instantiate(RightPrefabCube[Rand], RightStartPoint[Random.Range(0, RightStartPointnum)].transform.position, RightStartPoint[Random.Range(0, RightStartPointnum)].transform.rotation);     //5.  //6.
                        Rigidbody2D rigidbody = Object.GetComponent<Rigidbody2D>();
                        if (Rand != 2)                                                                 //로켓 아닐때 == 새일때
                        {
                            rigidbody.AddForce(ForRight * 40f, ForceMode2D.Impulse);
                        }
                        else                                                                           //로켓일때
                        {
                            rigidbody.AddForce(ForRight * 80f, ForceMode2D.Impulse);

                        }
                    }

                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.GameOver) 
        {
            timer += Time.deltaTime;                //타이머 구현
            if (timer > DelayTime)
            {
                timer = 0.0f;
                if (Random.Range(0, RandDenominator) == 0)
                {
                    ReadyToMake = true;
                }
                else
                {
                    ReadyToMake = false;

                }
                
            }
        }
    }


    /*
    
    GameObject worldCube;
    public GameObject[] prefabCube;
    public GameObject[] StartPoint;//StartPoint
    float xval = 0.4f;
    bool isMove;
    float gravity = 0;
    bool start;
    int cubenum;
    
    private void Start()
    {
        cubenum = prefabCube.GetLength(0);
    }
    
    void Startsequence()
    {


        worldCube = Instantiate(prefabCube[Random.Range(0, cubenum)]);
        worldCube.transform.position = StartPoint[Random.Range(0, 3)].transform.position;
        worldCube.GetComponent<Rigidbody2D>().gravityScale = 0;
        isMove = false;

    }
    void start_true()
    {
        start = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            //Startsequence();
            start = false;
        }
        if (!GameManager.instance.GameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {

                isMove = true;
                worldCube.GetComponent<Rigidbody2D>().gravityScale = 12;
                Invoke("start_true", 2f);

            }

            //if (!isMove)
            //{
            //    worldCube.transform.position += new Vector3(xval, 0, 0);
            //    if (worldCube.transform.position.x > 26.0f) xval = -xval;
            //    else if (worldCube.transform.position.x < -26.0f) xval = Mathf.Abs(xval);
            //}
        }

    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.GameOver)
        {
            if (!isMove)
            {
                worldCube.transform.position += new Vector3(xval, 0, 0);
                if (worldCube.transform.position.x > 26.0f) xval = -xval;
                else if (worldCube.transform.position.x < -26.0f) xval = Mathf.Abs(xval);
            }
        }
    }
    */

}


