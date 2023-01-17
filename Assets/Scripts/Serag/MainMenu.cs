using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioClip BtnClip;
    //private AudioClip playGameBtnClip;

    //private void Awake()
    //{
    //    GameManager.Singelton.onGameStart += Playgame;
    //    GameManager.Singelton.onGameEnd += QuitGame;
    //}
    public void Playgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Game started");
        //SceneManager.LoadScene(1);
        //AudioManager.instance.PlayButtonSounds(BtnClip);
        SceneManager.LoadScene("Zewail Scene",LoadSceneMode.Single);
    }

    public void  QuitGame()
    {
        //AudioManager.instance.PlayButtonSounds(BtnClip);
        //Debug.Log("quit");
        Application.Quit();
    }

    public void PlayButtonClickSound()
    {
        AudioManager.instance.PlayButtonSounds(BtnClip);
    }
}
