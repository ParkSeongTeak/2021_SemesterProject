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

    private void Start()
    {
        start_true();
        cubenum = prefabCube.GetLength(0);
        Debug.Log(cubenum);
    }

    void Startsequence()
    {


        worldCube = Instantiate(prefabCube[Random.Range(0, cubenum)]);
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

            if (!isMove)
            {
                worldCube.transform.position += new Vector3(xval, 0, 0);
                if (worldCube.transform.position.x > 26.0f) xval = -xval;
                else if (worldCube.transform.position.x < -26.0f) xval = Mathf.Abs(xval);
            }
        }
        
    }
}
