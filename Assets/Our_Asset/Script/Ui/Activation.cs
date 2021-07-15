using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public GameObject gameObject;
    public void Active_True()
    {
        gameObject.SetActive(true);
    }
    public void Active_False()
    {
        gameObject.SetActive(false);

    }
}
