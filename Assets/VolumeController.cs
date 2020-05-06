using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VolumeController : MonoBehaviour
{
    public Slider slider;

    public static float volume;

    void Start()
    {
        volume = FindObjectOfType<AudioManager>().GetVolume();
        Debug.Log(volume);
        slider.maxValue = 1;
        slider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != volume)
        {
            volume = slider.value;
            FindObjectOfType<AudioManager>().SetVolume(slider.value);
        }
    }
}
