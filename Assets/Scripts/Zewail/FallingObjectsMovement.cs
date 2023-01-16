using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectsMovement : MonoBehaviour
{
    /*
     I tried moving objects using transform.translate --> It worked but Rigidbody is also necessary for collision detection.
     I think the problem can be avoided if we used OnTriggerEnter2D instead of OnCollisionEnter2D but using a rigid body is not
     awful at the moment so we can use it and optimize later.
     */
    float fallingSpeed;
    Rigidbody2D rb2d;
    // Update is called once per frame
    private void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0.0f;
        fallingSpeed = Random.Range(2.5f, 12.0f);
    }
    //void Update()
    //{
    //    //rb2d.velocity = new Vector2(0, -fallingSpeed/* * Time.deltaTime*/);
    //    //transform.Translate(0, -fallingSpeed * Time.deltaTime, 0);
    //}
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(0, -fallingSpeed);
    }
}
