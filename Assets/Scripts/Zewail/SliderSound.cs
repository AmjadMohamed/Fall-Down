using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class SliderSound : MonoBehaviour
{
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.ChangeMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => { AudioManager.instance.ChangeMasterVolume(val); }) ;
    }
}
