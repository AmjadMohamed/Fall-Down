using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour
{
    private bool IsColliding = false;
    private GameObject NewParent;
    private GameObject RealParent;
    private Vector3 OriginalPos;
    private SpriteRenderer MyRenderer;

    private void Awake()
    {
        MyRenderer = GetComponent<SpriteRenderer>();
        OriginalPos = this.transform.position;
        if (this.transform.parent != null)
        {
            RealParent = this.transform.parent.gameObject;
        }

    }

    private void Update()
    {
        if (IsColliding)
        {
            if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.JoystickButton2) && !transform.parent.CompareTag("Player")) // ps3 square
            {
                print("should move");
                RealParent = this.transform.parent.gameObject;
                if (NewParent != null)
                {
                    transform.position = new Vector2(NewParent.transform.position.x, this.transform.position.y);
                    this.transform.SetParent(NewParent.transform);
                    //transform.position = Vector2.zero;
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
            if (NewParent != null)
            {
                NewParent.transform.SetParent(null);
                NewParent.GetComponent<PlayerController>().IsClimbing = false;
            }

        }

        if (this.transform.position.y < -5)
        {
            this.transform.position = OriginalPos;
            if (RealParent != null)
            {
                this.transform.SetParent(RealParent.transform);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision) // fe mo4kla bt7sl hena lamma msln agy a5od el selm and ykon fe player tany by collide m3ah, sa3at by5ly el player el tany how aelly ymsk el ladder
    {
        print("col enter");
        MyRenderer.color = Color.yellow;
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
        MyRenderer.color = Color.white;
        IsColliding = false;
        if (NewParent != null)
        {
            NewParent.GetComponent<PlayerController>().IsClimbing = false;
            NewParent.transform.SetParent(null);
            NewParent = null;
            // NewParent.GetComponent<PlayerController>().IsInteracting = false;
        }
    }
}
