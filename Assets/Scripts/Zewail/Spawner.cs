using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] int spawnAmount;
    int spawnTracker = 1;
    
    
    private void FixedUpdate()
    {
        //if(spawnTracker <= spawnAmount)
        //{
        //    Spawn();
        //}
        Spawn();
    }
    void Spawn()
    {
        GameObject fallObj = FallingObjectsPool.instance.Get();
        //fallingSpeed = Random.Range(2.5f, 12.0f);
        if (fallObj != null)
        {
            fallObj.transform.parent = transform;
            fallObj.transform.position = new Vector2(Random.Range(-7f, 7f), 7f);
            fallObj.SetActive(true);
            //fallObj.transform.Translate(0, fallingSpeed * Time.deltaTime, 0);
            //Debug.Log(fallObj.name + " Speed:" + fallingSpeed + "y-position: "+fallObj.transform.position.y);
        }
        
        spawnTracker++;
    }
}
