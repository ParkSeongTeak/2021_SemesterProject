using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraMoving : MonoBehaviour
{

    float movingspeed = 0.5f;
    [SerializeField] GameObject maincamera;

    private void Update()
    {
        if (GameManager.instance.firstHeight >=  maincamera.transform.position.y) //일단 임의의 숫자 넣음 -> 추후 192로 변경
        {
            Vector3 cubePos = new Vector3(this.transform.position.x, GameManager.instance.firstHeight + 3f, this.transform.position.z); //역시 임의의 숫자 -> 추후 480으로 변경
            transform.position = Vector3.Lerp(transform.position, cubePos, Time.deltaTime * movingspeed);
        }

    }
}