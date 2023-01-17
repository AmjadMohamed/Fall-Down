using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action onPlayerCollided;
    //public event Action onPlayerFall;
    //public event Action onLadderFall;
    //public event Action onGameStart;
    //public event Action onGameEnd;
    //public event Action onGamePaused;
    //public event Action onGameResume;

    //public GameState state;

    #region Singelton Creation
    private static GameManager instance;
    public static GameManager Singelton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        
    }
    #region Update Game State Method trial
    //public void UpdateGameState(GameState newState)
    //{
    //    state = newState;
    //    switch (newState)
    //    {
    //        case GameState.MainMenu:
    //            StartMainMenu();
    //            break;
    //        case GameState.PauseMenu:

    //            break;
    //        case GameState.CurrentLevel:

    //            break;
    //        case GameState.WinningScreen:

    //            break;
    //        default:
    //            Debug.Log("Wrong State");
    //            break;

    //    }
    //    onGameStateChange?.Invoke();
    //} 
    #endregion
    public void PlayerHit()
    {
        onPlayerCollided();
    }
    //public void StartGame()
    //{
    //    onGameStart();
    //}
    //public void EndGame()
    //{
    //    onGameEnd();
    //}
    //public void PauseGame()
    //{
    //    onGamePaused();
    //}
    //public void GameResume()
    //{
    //    onGameResume();
    //}


    #region Creating a singelton while using a monobehaviour
    //private static GameManager singelton = null;
    //[SerializeField] int spawnAmount = 5;
    //private void Awake()
    //{
    //    if(singelton == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else if(singelton != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //} 
    #endregion


}
//public enum GameState
//{
//    MainMenu,
//    PauseMenu,
//    CurrentLevel,
//    WinningScreen
//}

