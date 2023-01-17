using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallingObjectDestroyer : MonoBehaviour
{
    [SerializeField] UnityEvent onPlayerCollision;

    private void Update()
    {
        if (this.transform.position.y < -5)
        {
            FallingObjectsPool.instance.ReturnToPool(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            FallingObjectsPool.instance.ReturnToPool(this.gameObject);
        }
        else if (collision.collider.CompareTag("Player"))
        {
            FallingObjectsPool.instance.ReturnToPool(this.gameObject);
            onPlayerCollision.Invoke();
        }
    }
}
