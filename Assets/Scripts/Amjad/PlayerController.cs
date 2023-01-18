using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public
    [SerializeField] float MovSpeed;
    [SerializeField] float ClimbSpeed;
    public bool IsClimbing = false;



    // private
    Rigidbody2D rb2d;
    Vector2 moveInputVal;
    float VerticalMov;
    private Vector3 OriginalPos;
    Animator anim;
    SpriteRenderer sr;

    void Awake()
    {
        OriginalPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        VerticalMov = Input.GetAxis("Vertical");

        if (this.transform.position.y < -6)
        {
            this.transform.position = OriginalPos;
        }
        //print("vertical: " + VerticalMov);
    }

    private void FixedUpdate()
    {
        if (IsClimbing)
        {
            ClimbLadder();
        }
        else
        {
            Movement();
            LeaveLadder();
        }
    }

    // this method gets the move input from the OnMove Action
    public void OnMove(InputValue val)
    {
        //VerticalMov = val.Get<Vector2>().y;
        moveInputVal = val.Get<Vector2>();
    }

    private void Movement()
    {
        rb2d.velocity = new Vector2(moveInputVal.x * MovSpeed * Time.fixedDeltaTime, rb2d.velocity.y);

        if (anim != null)
        {
            if (rb2d.velocity.x != 0)
            {
                anim.SetBool("isMoving", true);
                if(rb2d.velocity.x > 0)
                {
                    sr.flipX= true;
                }
                else
                {
                    sr.flipX= false;
                }
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }
    }

    private void ClimbLadder()
    {
        rb2d.gravityScale = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, VerticalMov * ClimbSpeed * Time.fixedDeltaTime);
    }

    private void LeaveLadder()
    {
        rb2d.gravityScale = 4;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            OriginalPos = new Vector2(collision.transform.position.x, collision.transform.position.y + 1);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision) // fe mo4kla bt7sl hena lamma msln agy a5od el selm and ykon fe player tany by collide m3ah, sa3at by5ly el player el tany how aelly ymsk el ladder
    //{
    //    print("col enter");
    //    if (collision.CompareTag("Ladder"))
    //    {
    //        Ladder ladder = collision.GetComponent<Ladder>();
    //        if (ladder != null)
    //        {
    //            ladder.IsColliding = true;
    //            if (ladder.NewParent == null)
    //            {
    //                ladder.NewParent = this.gameObject;
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    print("col exit");
    //    Ladder ladder = collision.GetComponent<Ladder>();
    //    if (ladder != null)
    //    {
    //        ladder.IsColliding = false;
    //        if (ladder.NewParent != null)
    //        {
    //            this.GetComponent<PlayerController>().IsClimbing = false;
    //            this.transform.SetParent(null);
    //            ladder.NewParent = null;
    //            // NewParent.GetComponent<PlayerController>().IsInteracting = false;
    //        }
    //    }
    //}




}
