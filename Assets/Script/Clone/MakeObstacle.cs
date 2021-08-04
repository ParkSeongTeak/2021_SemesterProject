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
    public GameObject RightWarningBird;
    public GameObject RightWarningRocket;
    public GameObject LeftWarningBird;
    public GameObject LeftWarningRocket;

    GameObject Object;
    GameObject MainCamera;

    Vector3 HightVec = new Vector3(0, 550, 0);

    const int RandDenominator = 5;
    //const int RocketRand = 5;
    bool ReadyToMake;
    
    float timer;
    float DelayTime = 3.0f;

    int LeftPrefnum;
    int RightPrefnum;
    int LeftStartPointnum;
    int RightStartPointnum;
    int pointNum;
    int Rand;
    bool Left=false;

    Vector3 ForLeft = new Vector3(1, 0, 0);
    Vector3 ForRight = new Vector3(-1, 0, 0);
    Vector3 LeftWarnigPos = new Vector3(20, 0, 0);
    Vector3 RightWarnigPos = new Vector3(-20, 0, 0);



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

                if(MainCamera.transform.localPosition.y < HightVec.y )//1.기준치 이하일때
                {
                    pointNum = Random.Range(0, LeftStartPointnum);  //시작 위치
                    if(Random.Range(0, 2) == 0)                      //왼쪽 오른쪽
                    {
                        Left = true;
                    }
                    else
                    {
                        Left = false;

                    }
                    Rand = Random.Range(0, LeftPrefnum);          //장애물 확정
                    if (Left)   //왼쪽
                    {
                        if (Rand < 4)
                            Instantiate(LeftWarningBird, LeftStartPoint[pointNum].transform.position + LeftWarnigPos, LeftStartPoint[pointNum].transform.rotation);     //경고문 등장
                        else
                        {
                            Instantiate(LeftWarningRocket, LeftStartPoint[pointNum].transform.position + LeftWarnigPos, LeftStartPoint[pointNum].transform.rotation);     //경고문 등장
                        }

                    }
                    else
                    {
                                //오른쪽
                    }
                    {
                        if (Rand < 4)
                            Instantiate(RightWarningBird, RightStartPoint[pointNum].transform.position + RightWarnigPos, LeftStartPoint[pointNum].transform.rotation);     //경고문 등장
                        else
                        {
                            Instantiate(RightWarningRocket, RightStartPoint[pointNum].transform.position + RightWarnigPos, LeftStartPoint[pointNum].transform.rotation);     //경고문 등장
                        }
                    }
                    Invoke("MakeobstaclFirst", 3.0f);           //실 장애물 생성

                }


                else                //1. 기중치 이상일때 로켓만
                {
                    pointNum = Random.Range(0, LeftStartPointnum);  //시작 위치
                    if (Random.Range(0, 2) == 0)                      //왼쪽 오른쪽
                    {
                        Left = true;
                    }
                    else
                    {
                        Left = false;

                    }
                    Rand = Random.Range(4, LeftPrefnum);          //장애물 확정
                    if (Left)   //왼쪽
                    {
                        if (Rand < 4)
                            Instantiate(LeftWarningBird, LeftStartPoint[pointNum].transform.position + LeftWarnigPos, LeftStartPoint[pointNum].transform.rotation);     //경고문 등장
                        else
                        {
                            Instantiate(LeftWarningRocket, LeftStartPoint[pointNum].transform.position + LeftWarnigPos, LeftStartPoint[pointNum].transform.rotation);     //경고문 등장
                        }

                    }
                    else
                    {
                        //오른쪽
                    }
                    {
                        if (Rand < 4)
                            Instantiate(RightWarningBird, RightStartPoint[pointNum].transform.position + RightWarnigPos, LeftStartPoint[pointNum].transform.rotation);     //경고문 등장
                        else
                        {
                            Instantiate(RightWarningRocket, RightStartPoint[pointNum].transform.position + RightWarnigPos, LeftStartPoint[pointNum].transform.rotation);     //경고문 등장
                        }
                    }
                    Invoke("MakeobstaclSecond", 3.0f);


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


    public void MakeobstaclFirst() //기준치 이하 장애물 생성 위치
    {

        if (Left)  //4.왼쪽
        {
            
            Object = Instantiate(LeftPrefabCube[Rand], LeftStartPoint[pointNum].transform.position, LeftStartPoint[pointNum].transform.rotation);     //5.  //6.


            Rigidbody2D rigidbody = Object.GetComponent<Rigidbody2D>();
            if (Rand < 4)                                                                 //로켓 아닐때 == 새일때
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
            
            Object = Instantiate(RightPrefabCube[Rand], RightStartPoint[pointNum].transform.position, RightStartPoint[pointNum].transform.rotation);     //5.  //6.
            Rigidbody2D rigidbody = Object.GetComponent<Rigidbody2D>();
            if (Rand < 4)                                                                 //로켓 아닐때 == 새일때
            {
                rigidbody.AddForce(ForRight * 40f, ForceMode2D.Impulse);
            }
            else                                                                           //로켓일때
            {
                rigidbody.AddForce(ForRight * 80f, ForceMode2D.Impulse);

            }
        }
    }

    public void MakeobstaclSecond()    //기준치 이상일때
    {
        if (Left)  //4.왼쪽
        {
            Object = Instantiate(LeftPrefabCube[Rand], LeftStartPoint[pointNum].transform.position, LeftStartPoint[pointNum].transform.rotation);     //5.  //6.
            Rigidbody2D rigidbody = Object.GetComponent<Rigidbody2D>();
            
            rigidbody.AddForce(ForLeft * 80f, ForceMode2D.Impulse);
        }
        else                           //4.오른쪽
        {
         
            Object = Instantiate(RightPrefabCube[Rand], RightStartPoint[pointNum].transform.position, RightStartPoint[pointNum].transform.rotation);     //5.  //6.
            Rigidbody2D rigidbody = Object.GetComponent<Rigidbody2D>();
            
            rigidbody.AddForce(ForRight * 80f, ForceMode2D.Impulse);
        }
    }

}


