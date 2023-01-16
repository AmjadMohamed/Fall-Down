using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] GameObject fallingObject;
    [SerializeField] float fallingSpeed;
    //[SerializeField] Transform spawnPosition;

    //List<GameObject> pooledObjects = new List<GameObject>();
    
    [SerializeField] int spawnAmount;
    int spawnTracker = 1;
    
    // Update is called once per frame
    void Update()
    {
        if(spawnTracker <= spawnAmount)
        {
            Spawn();
        }
    }
    void Spawn()
    {
        GameObject fallObj = FallingObjectsPool.instance.Get();

        if (fallObj != null)
        {
            fallObj.transform.parent = transform;
            fallObj.transform.position = new Vector2(Random.Range(-5, 5), 5);
            fallObj.SetActive(true);
            fallObj.transform.Translate(0, fallingSpeed * Time.deltaTime, 0);
        }
        spawnTracker++;
    }
}
