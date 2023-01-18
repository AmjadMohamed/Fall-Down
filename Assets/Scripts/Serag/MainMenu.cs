using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource mainMenuMusic;
    [SerializeField] AudioSource btnSFX;
    //private AudioClip playGameBtnClip;

    private void Awake()
    {
        PlayMainMenuOST();
    }
    public void Playgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Game started");
        //SceneManager.LoadScene(1);
        PlayBtnSFX();
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void  QuitGame()
    {
        PlayBtnSFX();
        //Debug.Log("quit");
        Application.Quit();
    }
    public void PlayBtnSFX()
    {
        AudioManager.instance.PlayButtonSounds(btnSFX.clip);
    }

    public void PlayMainMenuOST()
    {
        AudioManager.instance.PlayMainMenuMusic(mainMenuMusic.clip);
        //if (SceneManager.GetActiveScene().buildIndex == 0) 
        //{
        //    AudioManager.instance.PlayButtonSounds(mainMenuMusic.clip);
        //}
    }
}
