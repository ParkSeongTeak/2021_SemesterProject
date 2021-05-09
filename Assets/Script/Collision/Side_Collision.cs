using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_Collision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);

        if(GameManager.instance.Is_Fever == false)
        {
            if (col.gameObject.tag == "First")
            {
                GameManager.instance.GameOver = true;
            }
        }
    }
}
