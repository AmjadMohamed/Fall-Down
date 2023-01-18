using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySound : MonoBehaviour
{
    [SerializeField] AudioClip gameplay;
    private void Start()
    {
        AudioManager.instance.PlayGamePlayMusic(gameplay);
    }

}
