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

    void Awake()
    {
        OriginalPos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
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
            OriginalPos = new Vector2(collision.transform.position.x, collision.transform.position.y+1);
        }
    }




}
