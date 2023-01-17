using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelDecrease : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Singelton.onPlayerCollided += DelayPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DelayPlayer()
    {
        
        //this.gameObject.transform.position = new Vector2(0, -5f);
        Debug.Log("Player is hit");
    }
}
