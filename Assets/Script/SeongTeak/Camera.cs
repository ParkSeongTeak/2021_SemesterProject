using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private void Update()
    {
        if (GameObject.FindWithTag("First").transform.position.y + GameObject.FindWithTag("First").transform.localScale.y/2 > this.transform.position.y){
            this.transform.position = new Vector3(0, GameObject.FindWithTag("First").transform.position.y + GameObject.FindWithTag("First").transform.localScale.y / 2 + 30, -100);

        }
    }
}
