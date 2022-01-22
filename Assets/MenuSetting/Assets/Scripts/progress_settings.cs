using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class progress_settings : MonoBehaviour
{
    [SerializeField]
    private GameObject Music_on;
    [SerializeField]
    private GameObject Music_off;
    [SerializeField]
    private GameObject Sounds_on;
    [SerializeField]
    private GameObject Sounds_off;
    [SerializeField]
    private AudioSource Click_Sound;
    [SerializeField]
    private AudioMixerGroup Mixer;
    [HideInInspector]
    private bool Music;
    private bool Sound;
    public static int SoundChecker, MusicChecker;

    private void Start()
    {
        SoundChecker = PlayerPrefs.GetInt("Sound");
        MusicChecker = PlayerPrefs.GetInt("Music");
        TonggleMusic();
        TonggleSounds();
    }
    public void Music_on_off()
    {
        if (Music_on.activeInHierarchy == true && Music_off.activeInHierarchy == false)
        {
            Music_on.SetActive(false);
            Music_off.SetActive(true);
            //Music = false; 
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            Music_on.SetActive(true);
            Music_off.SetActive(false);
            // Music = true;
            PlayerPrefs.SetInt("Music", 1);

        }
        Click_Sound.Play();
    }

    public void Sounds_on_off()
    {
        if (Sounds_on.activeInHierarchy == true && Sounds_off.activeInHierarchy == false)
        {
            Sounds_on.SetActive(false);
            Sounds_off.SetActive(true);
            // Sound = false;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            Sounds_on.SetActive(true);
            Sounds_off.SetActive(false);
            //Sound = true;
            PlayerPrefs.SetInt("Sound", 1);

        }
        Click_Sound.Play();
    }

    public void TonggleMusic()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
            Music_on.SetActive(true);
            Music_off.SetActive(false);
        }
        else
        {
            Mixer.audioMixer.SetFloat("MusicVolume", -80);
            Music_on.SetActive(false);
            Music_off.SetActive(true);
        }
        /* if (Music == true)
         Mixer.audioMixer.SetFloat("MusicVolume", 0);
         else
             Mixer.audioMixer.SetFloat("MusicVolume", -80);*/
    }

    public void TonggleSounds()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            Mixer.audioMixer.SetFloat("SoundVolume", 0);
            Sounds_on.SetActive(true);
            Sounds_off.SetActive(false);
        }
        else
        {
            Mixer.audioMixer.SetFloat("SoundVolume", -80);
            Sounds_on.SetActive(false);
            Sounds_off.SetActive(true);
        }
        /*if (Sound == true)
            Mixer.audioMixer.SetFloat("SoundVolume", 0);
        else
            Mixer.audioMixer.SetFloat("SoundVolume", -80);*/
    }

}
