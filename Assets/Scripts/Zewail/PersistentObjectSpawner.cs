using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject persistentGameObject = null;

    static bool hasSpawned = false;

    private void Awake()
    {
        if(hasSpawned) 
        {
            return;
        }
        GameObject persObj = Instantiate(persistentGameObject);
        DontDestroyOnLoad(persObj);
        hasSpawned = true;
    }
    
}
