using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
<<<<<<< HEAD
    //[SerializeField] levelSpawnAmount level = levelSpawnAmount.level_1;
    //int spawnAmount = GameManager.Singelton.SpawnAmount;
    [SerializeField] int spawnAmount = 5;
    
=======

    //[SerializeField] int spawnAmount;
    //int spawnTracker = 0;
    [SerializeField] levelSpawnAmount level = levelSpawnAmount.level_1;

<<<<<<< Updated upstream
=======
>>>>>>> 65bf3abf3a61e6227cb5be0604594ffa0b6aae11
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
        //spawnTracker++;
>>>>>>> 65bf3abf3a61e6227cb5be0604594ffa0b6aae11
    }
}
