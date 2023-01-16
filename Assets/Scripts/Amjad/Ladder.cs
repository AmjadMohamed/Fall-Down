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
                    this.transform.SetParent(NewParent.transform);
                    //NewParent.GetComponent<PlayerController>().IsInteracting = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.JoystickButton0)) // ps3 x
            {
                print("should climb");
                if (NewParent != null)
                {
                    NewParent.transform.position = this.transform.position;
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
            NewParent = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("col exit");
        IsColliding = false;
        if (NewParent != null)
        {
            NewParent.transform.SetParent(null);
            // NewParent.GetComponent<PlayerController>().IsInteracting = false;
        }
        NewParent = null;
    }
}
