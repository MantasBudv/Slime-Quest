using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VolumeController : MonoBehaviour
{
    public Slider slider;

    public static float volume = 40;
        // Start is called before the first frame update
        void Start()
    {
        slider.maxValue = 100;
        slider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != volume)
        {
            volume = slider.value;
        }
    }
}
