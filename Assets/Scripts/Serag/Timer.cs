using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunnig = true;
    public TMP_Text timeText;
    public GameObject PressAnyButtonTextGO;

    private void Start()
    {
        timeIsRunnig = false;
    }

    private void Update()
    {
        if (timeIsRunnig)
        {
            PressAnyButtonTextGO.SetActive(false);
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                timeText.text = DisplayTime(timeRemaining);
            }
        }
    }
    public string DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return string.Format("{00:00} : {1:00}", minutes, seconds);
    }
}
