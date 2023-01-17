using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallingObjectDestroyer : MonoBehaviour
{
    [SerializeField] UnityEvent onPlayerCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        { 
            FallingObjectsPool.instance.ReturnToPool(this.gameObject);
            
        }
        else if(collision.collider.CompareTag("Player"))
        {
            onPlayerCollision.Invoke();
        }
    }
}
