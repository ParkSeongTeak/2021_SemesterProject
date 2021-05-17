using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject worldCube;
    public GameObject prefabCube;
    public GameObject[] Cubes;
    float xval = 0.1f;
    bool isMove;
    float gravity = 0;
    bool start;


    private void Start()
    {
        start = true;
        //worldCube = Instantiate(prefabCube);
        //worldCube.transform.position = Cubes[Random.Range(0, 3)].transform.position;
        //worldCube.GetComponent<Rigidbody2D>().gravityScale = 0;

    }

    void Startsequence()
    {
        worldCube = Instantiate(prefabCube);
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

        if (Input.GetMouseButtonDown(0))
        {

            isMove = true;
            worldCube.GetComponent<Rigidbody2D>().gravityScale = 4;
            Invoke("start_true",3f);
            
        }
        
        if (!isMove)
        {
            worldCube.transform.position += new Vector3(xval, 0, 0);
            if (worldCube.transform.position.x > 26.0f) xval = -0.1f;
            else if (worldCube.transform.position.x < -26.0f) xval = 0.1f;
        }
        
    }
}
