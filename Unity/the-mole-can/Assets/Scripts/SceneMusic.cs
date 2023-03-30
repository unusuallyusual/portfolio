using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMusic : MonoBehaviour
{
    [SerializeField] private GameObject sliderMusic;
    [SerializeField] private GameObject sliderEffects;

    private float musicVolume;
    private float soundEffectsVolume;
    private Slider sliderV;
    private Slider sliderE;

    private int i;

    public float MusicVolume => musicVolume;
    public float SoundEffectsVolume => soundEffectsVolume;

    private void Awake()
    {
        sliderV = sliderMusic.GetComponent<Slider>();
        sliderE = sliderEffects.GetComponent<Slider>();
    }

    private void Start()
    {
        AudioManager.instance.Play("Music");
    }

    private void Update()
    {
        AudioManager.instance.SetVolume("Music", musicVolume);
        foreach(Sound s in AudioManager.instance.sounds)
        {
            if (s.name != "Music")
                AudioManager.instance.SetVolume(s.name, soundEffectsVolume);
        }

        sliderV.value = musicVolume;
        sliderE.value = soundEffectsVolume;
    }

    public void SetMusicVolume(float vol)
    {
        musicVolume = vol;
    }
    public void SetEffectsVolume(float vol)
    {
        soundEffectsVolume = vol;
        if(i > 2)
            AudioManager.instance.Play("PlayerCollision");
        i++;
    }
}
