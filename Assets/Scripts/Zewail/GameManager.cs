using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager 
{
    public event Action onPlayerCollided;
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

    public void PlayerHit()
    {
        onPlayerCollided();
    }
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
