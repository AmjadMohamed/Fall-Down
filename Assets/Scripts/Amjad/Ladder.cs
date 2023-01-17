using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour
{
    private bool IsColliding = false;
    private GameObject NewParent;
    private GameObject RealParent;

    private void Awake()
    {
        if (this.transform.parent != null)
        {
            RealParent = this.transform.parent.gameObject;
        }
    }

    private void Update()
    {
        if (IsColliding)
        {
            if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.JoystickButton2)) // ps3 square
            {
                print("should move");
                RealParent = this.transform.parent.gameObject;
                if (NewParent != null)
                {
                    transform.position = new Vector2(NewParent.transform.position.x, this.transform.position.y);
                    this.transform.SetParent(NewParent.transform);
                    //NewParent.GetComponent<PlayerController>().IsInteracting = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.JoystickButton0)) // ps3 x
            {
                print("should climb");
                if (NewParent != null)
                {
                    NewParent.GetComponent<PlayerController>().IsClimbing = true;
                    NewParent.transform.position = new Vector3(this.transform.position.x, NewParent.transform.position.y, NewParent.transform.position.z);
                    NewParent.transform.SetParent(this.gameObject.transform);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.JoystickButton1)) // ps3 circle
        {
            print("should leave");
            if (RealParent != null)
            {
                this.transform.SetParent(RealParent.transform);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        print("col enter");
        if (collision.CompareTag("Player"))
        {
            IsColliding = true;
            if (NewParent == null)
            {
                NewParent = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("col exit");
        IsColliding = false;
        NewParent.GetComponent<PlayerController>().IsClimbing = false;
        if (NewParent != null)
        {
            NewParent.transform.SetParent(null);
            NewParent = null;
            // NewParent.GetComponent<PlayerController>().IsInteracting = false;
        }
    }
}
