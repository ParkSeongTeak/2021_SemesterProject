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
            if (col.gameObject.tag != "Obstacle" && col.gameObject.tag != "First" && col.gameObject.tag != "Side" && col.gameObject.tag != "Second")
            {
                //Destroy(col.gameObject);
                Debug.Log("Obstacle");

                GameOver.GetComponent<gameOver>().Gameover();

            }
            else
            {
                Destroy(this.gameObject);
            }

        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
