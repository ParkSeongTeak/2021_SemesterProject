using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundStart : MonoBehaviour
{
    public AudioMixer masterMixer;
    // Start is called before the first frame update
    void Start()
    {
        
        masterMixer.SetFloat("Master", GameManager.instance.GetSound());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
