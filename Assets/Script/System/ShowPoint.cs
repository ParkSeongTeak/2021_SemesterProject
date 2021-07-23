using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShowPoint : MonoBehaviour
{
    public Text showPoint;
    public Text MaxPoint;
    private void Start()
    {
        Print_Text();
        MaxPoint.text = "" + GameManager.instance.Get_Max_Point();
    }
    
    public void Print_Text() {
        showPoint.text = "" + GameManager.instance.Get_Point;
    }

}
