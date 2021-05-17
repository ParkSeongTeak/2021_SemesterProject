using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_Collision : MonoBehaviour
{
    GameObject GameOver;
    private void Awake()
    {
        GameOver = GameObject.Find("EventSystem");
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);

        if(GameManager.instance.Is_Fever == false)
        {
            if (col.gameObject.tag == "First")
            {
                Debug.Log("GameOVer");
                GameOver.GetComponent<gameOver>().Gameover(); ;
            }
        }
    }
}
