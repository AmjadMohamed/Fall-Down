using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource mainMenu, effects, win;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayButtonSounds(AudioClip clip)
    {
        mainMenu.PlayOneShot(clip);
    }
    public void PlayEffectsSounds(AudioClip clip)
    {
        effects.PlayOneShot(clip);
    }
    public void ChangeMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
