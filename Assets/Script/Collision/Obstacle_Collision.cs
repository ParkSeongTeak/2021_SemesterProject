using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Collision : MonoBehaviour
{
    GameObject GameOver;
    private void Awake()
    {
        GameOver = GameObject.Find("EventSystem");
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (GameManager.instance.Is_Fever == false)
        {
            if (col.gameObject.tag == "Controllable")
            {
                //Destroy(col.gameObject);
                GameOver.GetComponent<gameOver>().Gameover();

            }

        }
    }
}
