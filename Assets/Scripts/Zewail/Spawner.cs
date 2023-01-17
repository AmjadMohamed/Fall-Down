using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //[SerializeField] int spawnAmount;
    //int spawnTracker = 0;
    [SerializeField] levelSpawnAmount level = levelSpawnAmount.level_1;
    
    private void FixedUpdate()
    {
        Spawn(level);
    }
    void Spawn(levelSpawnAmount Level)
    {
        GameObject fallObj = FallingObjectsPool.instance.Get(Level);

        //fallingSpeed = Random.Range(2.5f, 12.0f);
        if (fallObj != null)
        {
            fallObj.transform.parent = transform;
            fallObj.transform.position = new Vector2(Random.Range(-10f, 10f), 7f);
            fallObj.SetActive(true);
            //fallObj.transform.Translate(0, fallingSpeed * Time.deltaTime, 0);
            //Debug.Log(fallObj.name + " Speed:" + fallingSpeed + "y-position: "+fallObj.transform.position.y);
        }
        
        //spawnTracker++;
    }
}
