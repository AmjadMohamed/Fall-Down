using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementSound : MonoBehaviour
{
    [SerializeField] AudioClip movement;
    private void Start()
    {
        AudioManager.instance.PlayMovementSounds(movement);
    }

}
