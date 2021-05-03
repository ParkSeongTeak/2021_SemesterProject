using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource Fx;
    public AudioClip click;

    public void Click()
    {
        Fx.PlayOneShot(click);
    }
}
