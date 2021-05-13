using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloneing : MonoBehaviour
{

    public GameObject Clone;
    public GameObject Mother;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateClone()
    {
        Instantiate(Clone,Mother.transform.position,Mother.transform.rotation);
    }

}
