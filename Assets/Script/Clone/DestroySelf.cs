using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour
{

    public float DestroyTime = 8.0f;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    
}
