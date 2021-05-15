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
    bool isMove = false;
    void Start()
    {
        
        worldCube = Instantiate(prefabCube);
        worldCube.transform.position = new Vector3(Random.Range(-1, 2)*13.0f, 20, 0);
        worldCube.GetComponent<Rigidbody2D>().gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMove = true;
            worldCube.GetComponent<Rigidbody2D>().gravityScale = 1;
        }



        if (!isMove)
        {
            worldCube.transform.position += new Vector3(xval, 0, 0);
            if (worldCube.transform.position.x > 26.0f) xval = -0.1f;
            else if (worldCube.transform.position.x < -26.0f) xval = 0.1f;
        }
        
    }
}
