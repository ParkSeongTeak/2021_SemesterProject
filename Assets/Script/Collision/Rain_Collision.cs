using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_Collision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag!="Side")
        {
            
        }
    }
}
