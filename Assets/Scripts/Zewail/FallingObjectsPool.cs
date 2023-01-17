using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum levelSpawnAmount
{
    level_1 = 5, level_2 = 10, level_3 = 20
}
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

    public GameObject Get(levelSpawnAmount level)
    {
        for (int i = 0; i < (int)level; i++)
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
