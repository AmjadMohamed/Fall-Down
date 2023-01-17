using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingObjectsInTargetGroup : MonoBehaviour
{
    GameObject[] players;
    CinemachineTargetGroup CTG;
    Cinemachine.CinemachineTargetGroup.Target target;

    private void Start()
    {
        CTG = this.GetComponent<CinemachineTargetGroup>();
    }

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
           // CTG.m_Targets = new CinemachineTargetGroup.Target[players[i]];
        }
    }
}
