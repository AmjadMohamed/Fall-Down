using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    bool IsCollidingWithALadder = false;
    [SerializeField] private GameObject RealParent;
    [SerializeField] private GameObject Ladder;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (IsCollidingWithALadder)
        {
            if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.JoystickButton2)) // ps3 square
            {
                //MovingLadder();
            }
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.JoystickButton0)) // ps3 x
            {
                // ClimbingLadder();
            }
        }
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.JoystickButton1)) // ps3 circle
        {
            // LeavingLadder();
        }
    }

    public void OnMovingLadder(InputAction.CallbackContext context)
    {
        if (context.performed && IsCollidingWithALadder)
        {
            print("should move");
            if (Ladder != null)
            {
                Ladder.transform.position = new Vector2(this.transform.position.x, Ladder.transform.position.y);
                Ladder.transform.SetParent(this.gameObject.transform);
            }
        }
    } // action when the player moves the ladder

    public void OnLeavingLadder(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("should leave");

            if (this.transform.parent != null) // leave climbing the ladder
            {
                this.transform.SetParent(null);
                playerController.IsClimbing = false;
            }

            if (this.transform.childCount > 0)
            {
                if (RealParent != null) // if I was holding the ladder, re assign it to its real parent
                {
                    this.transform.GetChild(0).transform.SetParent(RealParent.transform);
                    RealParent = null;
                }
            }
        }
    } // action when the player leaves the ladder
    public void OnClimbingLadder(InputAction.CallbackContext context)
    {
        if (context.performed && IsCollidingWithALadder)
        {
            print("should climb");
            if (Ladder != null)
            {
                playerController.IsClimbing = true;
                this.transform.position = new Vector2(Ladder.transform.position.x, this.transform.position.y);
                this.transform.SetParent(Ladder.transform);
            }
        }
    } // action when the player climbs the ladder

    private void OnTriggerEnter2D(Collider2D collision) // make the collided ladder a candidate that a player can use
    {
        if (collision.transform.CompareTag("Ladder"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            IsCollidingWithALadder = true;
            RealParent = collision.transform.parent.gameObject;
            Ladder = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // leaving the ladder
    {
        if (collision.transform.CompareTag("Ladder"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            IsCollidingWithALadder = false;
            playerController.IsClimbing = false;
            this.transform.SetParent(null);
            Ladder = null;
        }
    }
}
