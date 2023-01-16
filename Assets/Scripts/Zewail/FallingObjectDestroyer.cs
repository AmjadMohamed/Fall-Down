using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectDestroyer : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        { 
            FallingObjectsPool.instance.ReturnToPool(this.gameObject);
        }
    }
}
