using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinedPlayersController : MonoBehaviour
{
    private void OnPlayerJoined(PlayerInput playerInput)
    {
        SetPlayerPosition(playerInput.transform);
        GettingObjectsInTargetGroup.Instance.AddPlayerToTheTargetGroup(playerInput.transform);
    }

    void SetPlayerPosition(Transform player)
    {
        player.transform.position = new Vector2(Random.Range(-3.0f, 3.0f), 5);
    }
}
