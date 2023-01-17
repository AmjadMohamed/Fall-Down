using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIspasued = false;
    public GameObject PauseMenuUI;
    [SerializeField] AudioClip BtnClip;

    private void Awake()
    {
        //GameManager.Singelton.onGameResume += Resume;
        //GameManager.Singelton.onGameEnd += QuitGame;
        PauseMenuUI.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Escape is pressed");
            if (GameIspasued)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIspasued = false;
    }
    void Pause()
    {
        //Debug.Log("Pause menu");
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIspasued = true;
    }

    public void LoadMainMenu()
    {
        //Debug.Log("Main Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu"); //transaction between scenes 
        //GameManager.Singelton.StartGame();
    }
    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
    public void PlayButtonClickSound()
    {
        AudioManager.instance.PlayButtonSounds(BtnClip);
    }
}
