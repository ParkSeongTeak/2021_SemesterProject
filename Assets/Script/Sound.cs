using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
   
    public AudioMixer masterMixer;
    public Slider audioSlider;
    private void Start()
    {
        audioSlider.value = GameManager.instance.GetSound();
    }
    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);
        GameManager.instance.SaveSound(sound);


    }
   
    // Start is called before the first frame update
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
