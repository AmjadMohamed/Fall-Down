using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //private void Awake()
    //{
    //    GameManager.Singelton.onGameStart += Playgame;
    //    GameManager.Singelton.onGameEnd += QuitGame;
    //}
    public void Playgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("Game started");
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene("Zewail Scene",LoadSceneMode.Single);
    }

    public void  QuitGame()
    {
        //Debug.Log("quit");
        Application.Quit();
    }
}
