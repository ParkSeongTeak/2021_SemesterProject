using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    public Slider backVolume;
    public AudioSource audio;

    float backVol = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backVol", 1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(audio.volume != backVolume.value)
            SoundSlider();
    }
    void SoundSlider()
    {
        audio.volume = backVolume.value;

        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backVol", backVol);
    }

}
