using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosControl : MonoBehaviour
{
    public AudioSource soundsSource, musicSource;
    public AudioClip screamAudio, heartAudio, keyAudio, eAudio;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        soundsSource.volume = PlayerPrefs.GetFloat("SoundsVolume");
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        AudioListener.volume = PlayerPrefs.GetFloat("AllVolume");
    }
    public void AudioPlay(string audioName)
    {
        switch (audioName)
        {
            case "scream":
                soundsSource.clip = screamAudio;
                soundsSource.Play();
                break;
            case "heart":
                soundsSource.clip = heartAudio;
                soundsSource.Play();
                break;
            case "key":
                soundsSource.clip = keyAudio;
                soundsSource.Play();
                break;
            case "e":
                soundsSource.clip = eAudio;
                soundsSource.Play();
                break;
        }
    }
}