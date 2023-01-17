using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerLevelManager: MonoBehaviour
{
    private static TowerLevelManager instance;
    public static TowerLevelManager Instance { get => instance; set => instance = value; }

    public int TopLevel = 3;
    public int BottomLevel = 1;
    public List<GameObject> Levels;

    private void Start()
    {
        if(!Instance)
        {
            Instance = this;
        }

    }


}
