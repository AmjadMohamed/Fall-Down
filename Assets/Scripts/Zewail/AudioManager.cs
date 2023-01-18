using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource mainMenu, button, gameplay, win, movement, falling; 
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
        //GameManager.Singelton.onPlayerMove += PlayMovementSounds;
        //GameManager.Singelton.onPlayerFall += PlayFallingSFX;
        //GameManager.Singelton.onPlayerWin += PlayWinSFX;
        
    }

    public void PlayButtonSounds(AudioClip clip)
    {
        button.PlayOneShot(clip);

    }
    public void PlayMainMenuMusic(AudioClip clip) 
    {
        mainMenu.PlayOneShot(clip);
    }
    public void PlayMovementSounds(AudioClip clip)
    {
        movement.PlayOneShot(clip);
        //effects.PlayOneShot(clip);
    }
    public void PlayGamePlayMusic(AudioClip clip)
    {
        gameplay.PlayOneShot(clip);
        //effects.PlayOneShot(clip);
    }
    public void PlayWinSFX(AudioClip clip)
    {
        win.PlayOneShot(clip);
        //effects.PlayOneShot(clip);
    }
    public void PlayFallingSFX(AudioClip clip)
    {
        falling.PlayOneShot(clip);
        //effects.PlayOneShot(clip);
    }
    public void ChangeMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
