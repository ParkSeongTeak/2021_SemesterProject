using UnityEngine;
using System.Collections;

public class moveThis : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log(transform.position.x);
    }
}