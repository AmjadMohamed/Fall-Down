using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
=======

public enum levelSpawnAmount
{
    level_1 = 1, level_2 = 10, level_3 = 20, endLevel = 0
}
>>>>>>> 65bf3abf3a61e6227cb5be0604594ffa0b6aae11
public class FallingObjectsPool : MonoBehaviour
{
    
    public static FallingObjectsPool instance;
    [SerializeField] List<GameObject> fallingObjects;
    [SerializeField] List<GameObject> pooledfallingObjects;
    
    
    [SerializeField] int poolCapacity;
    bool isMaxSpawn = false;
    public int PoolCount { get { return poolCapacity; } }
    public bool IsMaxSpawn { get { return isMaxSpawn; } set { isMaxSpawn = value; } }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledfallingObjects = new List<GameObject>();
        #region Using Foreach loop and using a FallingObject Class
        //foreach(FallingObject fObj in fallingObjects) 
        //{
        //    for(int i = 0; i < poolCapacity;i++)
        //    {
        //        GameObject fallObj = Instantiate(fObj.Prefab);
        //        fallObj.SetActive(false);
        //        pooledfallingObjects.Add(fallObj);
        //    }
        //}

        /*foreach (GameObject fObj in fallingObjects)
        {
            for (int i = 0; i < poolCapacity; i++)
            {
                GameObject fallObj = Instantiate(fObj);
                fallObj.SetActive(false);
                pooledfallingObjects.Add(fallObj);
            }
        }*/ 
        #endregion
        for(int i = 0; i < poolCapacity; i++)
        {
            int randomSpawner = Random.Range(0, fallingObjects.Count);
            GameObject fallObj = Instantiate(fallingObjects[randomSpawner]);
            fallObj.SetActive(false);
            pooledfallingObjects.Add(fallObj);
            fallObj.transform.parent = transform;
        }
    }

    public GameObject Get(int spawnAmount)
    {
<<<<<<< Updated upstream
        for (int i = 0; i < poolCapacity/*(int)level*/; i++)
=======
<<<<<<< HEAD
        for (int i = 0; i < spawnAmount; i++)
=======
        for (int i = 0; i < poolCapacity/*(int)level*/; i++)
>>>>>>> 65bf3abf3a61e6227cb5be0604594ffa0b6aae11
>>>>>>> Stashed changes
        {
            if (!pooledfallingObjects[i].activeInHierarchy/* && !isMaxSpawn*/)
            {
                return pooledfallingObjects[i];
            }
        }
        return null;
    }

    public void ReturnToPool(GameObject fallObj)
    {
        fallObj.SetActive(false);
        fallObj.transform.parent = transform;
    }
    
}
