using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReTwinCollision : MonoBehaviour
{
    GameObject PointText;

    public GameObject[] twin = new GameObject[2];
    int cnt;
    private void Start()
    {
        PointText = GameObject.Find("Point");
        this.twin[0].GetComponent<Controllable_Collision>().IsTwin = true;
        this.twin[1].GetComponent<Controllable_Collision>().IsTwin = true;
        this.twin[0].GetComponent<Controllable_Collision>().TwinParant = this.gameObject;
        this.twin[1].GetComponent<Controllable_Collision>().TwinParant = this.gameObject;
        this.cnt = 0;

    }


    public void UPCount()
    {
        this.cnt++;
        if(this.cnt == 2)
        {
            GameManager.instance.Get_Point +=2 ;
            PointText.GetComponent<ShowPoint>().Print_Text();
            GameManager.instance.firstHeight = this.gameObject.transform.position.y;

        }
    }

}
