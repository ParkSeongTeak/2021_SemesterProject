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
    public GameObject BeforeCube;

    float[] xval = new float[5];
    float Feverxval = 2.6f;
    int[] AccelPoint = new int[5];
    int idx = 0;
    

    bool isMove;
    float gravity = 0;
    bool start;
    int cubenum;
    Vector3 StartPoint;
    int cnt = 0;
    //bool firstcube = true;
    int cubeBeforeNum;                          // 저번 큐브 넘버 기억
    bool cube_Before2_4 = false;                 // 2*4 블록 중복막기  cubenum 기준 6 7 8 9 2*4큐브
    bool cube_Before4_2 = false;                 // 4*2 블록 중복막기


    const int Begin2_4 = 6;
    const int End2_4 = 9;

    const int Begin4_2 = 11;
    const int End4_2 = 11;

    float DemolitionTimer = 0f;
    bool Demolition = false;


    const int DemolitionStartHight = 10;
    const float DemolitionTimerNeedTime = 25f;
    bool AfterDemolition = false;

    Vector3 Down = new Vector3(0, -1, 0);
    private void Start()
    {
        xval[0] = 0.6933f;
        xval[1] = 0.832f;
        xval[2] = 1.04f;
        xval[3] = 1.386f;
        xval[4] = 2.08f;
        

        //가속포인트
        AccelPoint[0] = 10;
        AccelPoint[1] = 20;
        AccelPoint[2] = 30;
        AccelPoint[3] = 40;
        AccelPoint[4] = 2100000000;
        




        start_true();
        cubenum = prefabCube.GetLength(0);
        Startsequence();
        start = false;
    }

    void Startsequence()    //시작 시퀀스 블록을 조건에 따라 생성한다
    {
        cubeBeforeNum = Random.Range(0, cubenum);

        if (worldCube !=null)
            BeforeCube = worldCube;
        
        if (GameManager.instance.Is_Fever)                          //피버라면?
        {
            if (GameManager.instance.FeverCubeCount < 20)
            {
                GameManager.instance.FeverCubeCount += 1;
            }
            else
            {
                GameManager.instance.FeverEnd();
            }
        }
        

        if (GameManager.instance.Get_Point >= AccelPoint[idx])
        {
            idx += 1;
        }

        
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
        StartPoint = worldCube.transform.position;
        cnt = 0;
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
        if (BeforeCube == null)
        {
            if (!GameManager.instance.GameOver && !GameManager.instance.gameStop && !isMove)
            {

                isMove = true;
                if (!GameManager.instance.Is_Fever)
                {
                    worldCube.GetComponent<Rigidbody2D>().gravityScale = 12;
                    worldCube.GetComponent<Rigidbody2D>().AddForce(Down * 500f, ForceMode2D.Impulse);
                    Invoke("start_true", 2f);
                }
                else//피버일때
                {
                    worldCube.GetComponent<Rigidbody2D>().gravityScale = 12 * 1.5f;
                    worldCube.GetComponent<Rigidbody2D>().AddForce(Down * 500f * 1.5f, ForceMode2D.Impulse);
                    Invoke("start_true", 1.3f);
                }
                
            }
        }
        else if (BeforeCube.gameObject.tag != "Controllable")
        {
            if (!GameManager.instance.GameOver && !GameManager.instance.gameStop && !isMove)
            {
                isMove = true;
                if (!GameManager.instance.Is_Fever)
                {
                    worldCube.GetComponent<Rigidbody2D>().gravityScale = 12;
                    worldCube.GetComponent<Rigidbody2D>().AddForce(Down * 500f, ForceMode2D.Impulse);
                    Invoke("start_true", 2f);
                }
                else//피버일때
                {
                    worldCube.GetComponent<Rigidbody2D>().gravityScale = 12 * 1.5f;
                    worldCube.GetComponent<Rigidbody2D>().AddForce(Down * 500f * 1.5f, ForceMode2D.Impulse);
                    Invoke("start_true", 1.3f);
                }

            }
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

                if (!GameManager.instance.Is_Fever)
                {
                    worldCube.transform.position += new Vector3(xval[idx], 0, 0);
                }
                else
                {
                    worldCube.transform.position += new Vector3(Feverxval, 0, 0);

                }
                if (worldCube.transform.position == StartPoint)
                {
                    cnt++;
                    if(cnt >= 6)
                    {
                        GetKeyDown();
                    }
                }
                if (!GameManager.instance.Is_Fever)
                {
                    if (worldCube.transform.position.x > 26.0f) xval[idx] = -xval[idx];
                    else if (worldCube.transform.position.x < -26.0f) xval[idx] = Mathf.Abs(xval[idx]);
                }
                else
                {
                    if (worldCube.transform.position.x > 26.0f) Feverxval = -Feverxval;
                    else if (worldCube.transform.position.x < -26.0f) Feverxval = Mathf.Abs(Feverxval);

                }
            }
        }
    }
}
