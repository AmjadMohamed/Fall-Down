using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingSound : MonoBehaviour
{
    [SerializeField] AudioClip falling;
    private void Start()
    {
        //AudioManager.instance.PlayFallingSFX(falling);
    }

}
