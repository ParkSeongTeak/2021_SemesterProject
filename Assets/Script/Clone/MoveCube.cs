using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveCube : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject worldCube;
    public GameObject Demolitioncube;
    public GameObject[] prefabCube;
    public GameObject[] Cubes;
    float xval = 0.4f;
    bool isMove;
    float gravity = 0;
    bool start;
    int cubenum;
    int cubeBeforeNum;                          // 저번 큐브 넘버 기억
    bool cube_Before2_4 = false;                 // 2*4 블록 중복막기  cubenum 기준 6 7 8 9 2*4큐브
    bool cube_Before4_2 = false;                 // 4*2 블록 중복막기


    const int Begin2_4 = 6;
    const int End2_4 = 9;

    const int Begin4_2 = 20;
    const int End4_2 = 20;

    float DemolitionTimer = 0f;
    bool Demolition = false;


    const int DemolitionStartHight = 10;
    const float DemolitionTimerNeedTime = 10f;
    bool AfterDemolition = false;

    Vector3 Down = new Vector3(0, -1, 0);
    private void Start()
    {
        start_true();
        cubenum = prefabCube.GetLength(0);
        Startsequence();
        start = false;
    }

    void Startsequence()    //시작 시퀀스 블록을 조건에 따라 생성한다
    {
        
        cubeBeforeNum = Random.Range(0, cubenum);



        if ((cubeBeforeNum < Begin2_4 || cubeBeforeNum > End2_4) && (cubeBeforeNum < Begin4_2 || cubeBeforeNum > End4_2))
        {
            cube_Before2_4 = false;
            cube_Before4_2 = false;

        }
        else
        {
            if ((cubeBeforeNum >= Begin2_4 && cubeBeforeNum <= End2_4)) {
                if (cube_Before2_4)
                {
                    while (cube_Before2_4)
                    {  // cubenum 기준 6 7 8 9 2*4큐브
                        cubeBeforeNum = Random.Range(0, cubenum);
                        if (cubeBeforeNum < Begin2_4 || cubeBeforeNum > End2_4) cube_Before2_4 = false;

                    }
                }
                else
                {
                    cube_Before2_4 = true;
                }
            }
            else if ((cubeBeforeNum >= Begin4_2 && cubeBeforeNum <= End4_2))
            {
                if (cube_Before4_2)
                {
                    while (cube_Before4_2)
                    {  // cubenum 기준 20 2*4큐브
                        cubeBeforeNum = Random.Range(0, cubenum);
                        if (cubeBeforeNum < Begin4_2 || cubeBeforeNum > End4_2) cube_Before4_2 = false;

                    }
                }
                else
                {
                    cube_Before4_2 = true;
                }
            }
        }
        if (Demolition && !AfterDemolition)
        {
            worldCube = Instantiate(Demolitioncube);
            AfterDemolition = true;
            Demolition = false;
        }
        else
        {

            worldCube = Instantiate(prefabCube[cubeBeforeNum]);
            AfterDemolition = false;
            
        }

        worldCube.transform.position = Cubes[Random.Range(0, 3)].transform.position;
        worldCube.GetComponent<Rigidbody2D>().gravityScale = 0;
        isMove = false;

    }
    void start_true()
    {
        start = true;
    }
    // Update is called once per frame

    public void GetKeyDown()
    {
        
        if (!GameManager.instance.GameOver && !GameManager.instance.gameStop)
        {

            isMove = true;
            worldCube.GetComponent<Rigidbody2D>().gravityScale = 12;
            worldCube.GetComponent<Rigidbody2D>().AddForce(Down * 500f, ForceMode2D.Impulse);
            Invoke("start_true", 2f);



            //if (!isMove)
            //{
            //    worldCube.transform.position += new Vector3(xval, 0, 0);
            //    if (worldCube.transform.position.x > 26.0f) xval = -xval;
            //    else if (worldCube.transform.position.x < -26.0f) xval = Mathf.Abs(xval);
            //}
        }
    }
    void Update()
    {
        if (start && !GameManager.instance.gameStop)
        {
            Startsequence();
            start = false;
        }

    }
    private void FixedUpdate()
    {

        if (GameManager.instance.Get_Point >= DemolitionStartHight)
        {
            DemolitionTimer += Time.deltaTime;
            if (DemolitionTimer > DemolitionTimerNeedTime)
            {
                DemolitionTimer = 0.0f;
                if (Random.Range(0, 2) == 0)
                {
                    Demolition = true;
                }
                else
                {
                    Demolition = false;

                }
            }
        }


        if (!GameManager.instance.GameOver && !GameManager.instance.gameStop)
        {
            if (!isMove)
            {
                worldCube.transform.position += new Vector3(xval, 0, 0);
                if (worldCube.transform.position.x > 26.0f) xval = -xval;
                else if (worldCube.transform.position.x < -26.0f) xval = Mathf.Abs(xval);
            }
        }
    }
}
