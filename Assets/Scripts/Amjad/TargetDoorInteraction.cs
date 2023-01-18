using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoorInteraction : MonoBehaviour
{
    [SerializeField] JoinedPlayersController joinedPlayersController;
    [SerializeField] GameObject WinGamePanel;
    private int ArrivedPlayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ArrivedPlayers++;
            collision.GetComponent<PlayerController>().enabled = false;
        }
    }

    private void Update()
    {
        if (ArrivedPlayers == joinedPlayersController.PlayersCount && ArrivedPlayers > 0)
        {
            WinGamePanel.SetActive(true);
        }
    }
}
