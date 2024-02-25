using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    private Transform midLanePosition;
    
    public float laneOffset;
    public float collectOffset;

    private void Awake()
    {
        midLanePosition = transform;
    }

    public bool IsInsideCollectArea(Transform obj)
    {
        var min = transform.position.x - collectOffset;
        var max = transform.position.x + collectOffset;
        if (obj.transform.position.x > min && obj.transform.position.x < max)
            return true;
        return false;
    }
}
