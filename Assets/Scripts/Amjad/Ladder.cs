using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour
{
    GameObject myParent;
    private Vector3 OriginalPos;

    private void Awake()
    {
        OriginalPos = this.transform.position;
        if (this.transform.parent != null)
        {
            myParent = this.transform.parent.gameObject;
        }
    }

    private void Update()
    {
        if (this.transform.position.y < -5)
        {
            this.transform.position = OriginalPos;
            if (myParent != null)
            {
                this.transform.SetParent(myParent.transform);
            }
        }

    }
}
