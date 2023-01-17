using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEffector : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Effector2D>().useColliderMask = false;
    }
}
