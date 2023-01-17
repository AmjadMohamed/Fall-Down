using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsSounds : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    // Start is called before the first frame update
    public void PlayButtonClickSound()
    {
        AudioManager.instance.PlayButtonSounds(clip);
    }

}
