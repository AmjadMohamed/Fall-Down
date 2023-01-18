using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinedPlayersController : MonoBehaviour
{
    [SerializeField] Timer timer;
    [HideInInspector] public int PlayersCount;
    private void OnPlayerJoined(PlayerInput playerInput)
    {
        SetPlayerPosition(playerInput.transform);
        GettingObjectsInTargetGroup.Instance.AddPlayerToTheTargetGroup(playerInput.transform);
        timer.timeIsRunnig = true;
        PlayersCount++;
    }

    void SetPlayerPosition(Transform player)
    {
        player.transform.position = new Vector2(Random.Range(-3.0f, 3.0f), 5);
    }
}
