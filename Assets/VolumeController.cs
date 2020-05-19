using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VolumeController : MonoBehaviour
{
    public Slider slider;

    public static float volume;

    public Slider effectsSlider;

    public static float effectsVolume;

    void Start()
    {
        if (slider != null)
        {
            volume = FindObjectOfType<AudioManager>().GetVolumeOfBackground();
            Debug.Log(volume);
            slider.maxValue = 1;
            slider.value = volume;
        }
        
        if (effectsSlider != null)
        {
            effectsVolume = FindObjectOfType<AudioManager>().GetVolumeOfEffects();
            Debug.Log(effectsVolume);
            effectsSlider.maxValue = 1;
            effectsSlider.value = effectsVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slider != null && slider.value != volume)
        {
            volume = slider.value;
            FindObjectOfType<AudioManager>().SetVolumeOfBackground(slider.value);
        }
        if (effectsSlider != null && effectsSlider.value != effectsVolume)
        {
            effectsVolume = effectsSlider.value;
            FindObjectOfType<AudioManager>().SetVolumeOfEffects(effectsSlider.value);
        }
    }
}
