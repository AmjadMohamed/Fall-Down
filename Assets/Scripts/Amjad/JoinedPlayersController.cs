using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinedPlayersController : MonoBehaviour
{
    [SerializeField] Timer timer;
    [HideInInspector] public int PlayersCount;
    private void OnPlayerJoined(PlayerInput playerInput) // actions whem players joins the game
    {
        SetPlayerPosition(playerInput.transform);
        GettingObjectsInTargetGroup.Instance.AddPlayerToTheTargetGroup(playerInput.transform);
        timer.timeIsRunnig = true;
        PlayersCount++;
    }

    void SetPlayerPosition(Transform player) // setting random start positions for the players
    {
        player.transform.position = new Vector2(Random.Range(-3.0f, 3.0f), 5);
    }
}
