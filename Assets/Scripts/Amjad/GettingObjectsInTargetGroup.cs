using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingObjectsInTargetGroup : MonoBehaviour
{
    private static GettingObjectsInTargetGroup instance;

    // this script gets all the joined players in the scene inside the target group to keep camera track of them all
    // private
    GameObject[] players;
    CinemachineTargetGroup CTG;
    List<CinemachineTargetGroup.Target> targets;

    public static GettingObjectsInTargetGroup Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }
    private void Start()
    {
        CTG = this.GetComponent<CinemachineTargetGroup>();
        targets = new List<CinemachineTargetGroup.Target>();

    }

    public void AddPlayerToTheTargetGroup(Transform player)
    {
        targets.Add(new CinemachineTargetGroup.Target { target = player, radius = 0f, weight = 1f });
        CTG.m_Targets = targets.ToArray();
    }
}
