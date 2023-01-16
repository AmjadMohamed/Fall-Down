using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public
    [SerializeField] float speed;
    //public bool IsInteracting = false;



    // private
    Rigidbody2D rb2d;
    Vector2 moveInputVal;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    // this method gets the move input from the OnMove Action
    public void OnMove(InputValue val)
    {
        moveInputVal = val.Get<Vector2>();
        //print(moveInputVal.x);
    }

    private void Movement()
    {
        rb2d.velocity = new Vector2(moveInputVal.x * speed * Time.fixedDeltaTime, rb2d.velocity.y);
    }




}
