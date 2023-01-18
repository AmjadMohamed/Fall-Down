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
    [SerializeField] WinSound WinSound;
    [SerializeField] GameplaySound gameplaysound;
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
        if (ArrivedPlayers == joinedPlayersController.PlayersCount && ArrivedPlayers > 0)
        {
            //gameplaysound.gameObject.SetActive(false);
            WinSound.gameObject.SetActive(true);
            //AudioManager.instance.PlaySFX(sfxNames.Win);
            WinGamePanel.SetActive(true);
            timer.timeIsRunnig = false;
        }
    }
}
