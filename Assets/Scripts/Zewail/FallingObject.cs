using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int amount;

    public int Amount { get { return amount; } }
    public GameObject Prefab { get { return prefab; } }

}
