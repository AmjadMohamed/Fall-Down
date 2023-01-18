using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //[SerializeField] AudioSource mainMenuMusic;
    //[SerializeField] AudioSource btnSFX;
    //private AudioClip playGameBtnClip;

    
    public void Playgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Before Game started");
        //SceneManager.LoadScene(1);
        PlayBtnSFX();
        SceneManager.LoadScene(1,LoadSceneMode.Single);
        Debug.Log("After Game started");
        AudioManager.instance.PlayMusic(musicNames.Gameplay);
    }

    public void  QuitGame()
    {
        PlayBtnSFX();
        //Debug.Log("quit");
        Application.Quit();
    }
    public void PlayBtnSFX()
    {
        AudioManager.instance.PlaySFX(sfxNames.Buttons);
    }

    //public void PlayMainMenuOST()
    //{
    //    AudioManager.instance.PlaySFX(soundNames.Buttons);
    //    //if (SceneManager.GetActiveScene().buildIndex == 0) 
    //    //{
    //    //    AudioManager.instance.PlayButtonSounds(mainMenuMusic.clip);
    //    //}
    //}
}
