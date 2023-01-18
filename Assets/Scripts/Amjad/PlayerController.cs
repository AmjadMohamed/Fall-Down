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
            LeaveLadder();
            Movement();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInputVal = context.ReadValue<Vector2>();
    }

    private void Movement()
    {
        rb2d.velocity = new Vector2(moveInputVal.x * MovSpeed * Time.fixedDeltaTime, rb2d.velocity.y);

        if (anim != null)
        {
            if (rb2d.velocity.x != 0)
            {
                anim.SetBool("isMoving", true);
                if (rb2d.velocity.x > 0)
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
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
        rb2d.velocity = new Vector2(0, moveInputVal.y * ClimbSpeed * Time.fixedDeltaTime);
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
}
