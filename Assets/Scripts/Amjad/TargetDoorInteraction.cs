using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetDoorInteraction : MonoBehaviour
{
    [SerializeField] JoinedPlayersController joinedPlayersController;
    [SerializeField] GameObject WinGamePanel;
    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI TimeCounter;
    [SerializeField] TextMeshProUGUI Results;
    //[SerializeField] AudioClip WinSound;
    private int ArrivedPlayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ArrivedPlayers++;
            collision.GetComponent<PlayerController>().enabled = false;
            collision.transform.tag = "Untagged";
            Results.text += $"{ArrivedPlayers}- {collision.GetComponent<Animator>().runtimeAnimatorController.name} -> {TimeCounter.text}\n";
        }
    }

    private void Update()
    {
        if (ArrivedPlayers == joinedPlayersController.PlayersCount && ArrivedPlayers > 0) // the end game condition
        {
            WinGamePanel.SetActive(true);
            timer.timeIsRunnig = false;
        }
    }
}
