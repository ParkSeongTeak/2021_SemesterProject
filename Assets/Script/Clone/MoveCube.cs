using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveCube : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject worldCube;
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


        if (cubeBeforeNum < Begin2_4 || cubeBeforeNum > End2_4) cube_Before2_4 = false;
        else {
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

        worldCube = Instantiate(prefabCube[cubeBeforeNum]);
        worldCube.transform.position = Cubes[Random.Range(0, 3)].transform.position;
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
            Startsequence();
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
}
