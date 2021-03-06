﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        
            

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("BackgroundMusic");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();
    }
    public float GetVolumeOfBackground()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "BackgroundMusic");
        return s.source.volume;
    }
    public void SetVolumeOfBackground(float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == "BackgroundMusic");
        s.source.volume = volume;
    }
    public float GetVolumeOfEffects()
    {
        Sound s = Array.Find(sounds, sound => sound.name != "BackgroundMusic");
        return s.source.volume;
    }
    public void SetVolumeOfEffects(float volume)
    {
        Array.ForEach(sounds, sound => { if (sound.name != "BackgroundMusic") sound.source.volume = volume; });
    }
}
