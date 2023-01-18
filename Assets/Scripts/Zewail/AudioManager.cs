using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sounds
{
    int soundIndex;
    public AudioClip clip;
}
public enum musicNames
{
    MainMenu,Gameplay
}
public enum sfxNames
{
    Buttons, PlayerMovement, PlayerFalling, Win
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] Sounds[] musicSounds, sfxSounds;
    [SerializeField] AudioSource musicSource, sfxSource;

    public static AudioManager instance;
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
    private void Start()
    {
        PlayMusic(musicNames.MainMenu);
    }
    public void PlayMusic(musicNames music)
    {
        for(int i = 0; i < musicSounds.Length; i++) 
        {
            if (i == (int)music)
            {
                musicSource.clip = musicSounds[i].clip;
                //musicSource.PlayOneShot(musicSounds[i].clip);
                musicSource.Play();
                //return;
            }
        }
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlaySFX(sfxNames sfx)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if (i == (int)sfx)
            {
                
                sfxSource.clip = sfxSounds[i].clip;
                
                sfxSource.PlayOneShot(sfxSounds[i].clip);
                //return;
            }
        }
    }
    public void ChangeMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    //public void PlayButtonSounds(AudioClip clip)
    //{
    //    button.PlayOneShot(clip);

    //}
    //public void PlayMainMenuMusic(AudioClip clip) 
    //{
    //    mainMenu.PlayOneShot(clip);
    //}
    //public void PlayMovementSounds(AudioClip clip)
    //{
    //    movement.PlayOneShot(clip);
    //    //effects.PlayOneShot(clip);
    //}
    //public void PlayGamePlayMusic(AudioClip clip)
    //{
    //    gameplay.PlayOneShot(clip);
    //    //effects.PlayOneShot(clip);
    //}
    //public void PlayWinSFX(AudioClip clip)
    //{
    //    win.PlayOneShot(clip);
    //    //effects.PlayOneShot(clip);
    //}
    //public void PlayFallingSFX(AudioClip clip)
    //{
    //    falling.PlayOneShot(clip);
    //    //effects.PlayOneShot(clip);
    //}

}
