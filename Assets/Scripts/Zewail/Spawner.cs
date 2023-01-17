using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int spawnAmount = 5;
    
    

    private void FixedUpdate()
    {
        Spawn(spawnAmount);
    }
    void Spawn(int spawnAmount)
    {
        GameObject fallObj = FallingObjectsPool.instance.Get(spawnAmount);
        if (fallObj != null)
        {
            fallObj.transform.parent = this.transform;
            fallObj.transform.position = new Vector2(Random.Range( -5.5f, 5.5f), this.transform.position.y);
            fallObj.SetActive(true);
        }
    }
}
