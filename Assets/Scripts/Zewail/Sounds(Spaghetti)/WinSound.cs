using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSound : MonoBehaviour
{
    [SerializeField] AudioClip win;
    private void Start()
    {
        //AudioManager.instance.PlayWinSFX(win);
        AudioManager.instance.PlaySFX(sfxNames.Win);
    }

}
