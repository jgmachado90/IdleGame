using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int currentLane;
    [SerializeField] private float playerSpeed;

    public float PlayerSpeed
    {
        get { return playerSpeed; }
    }

    private LaneManager laneManager;

    private void Start()
    {
        laneManager = GameManager.Instance.laneManager;
        ChangeLane(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeLane(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeLane(-1);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GiveMoney();
        }
    }

    private void ChangeLane(int value)
    {
        float laneOffset = laneManager.laneOffset;
        currentLane = Mathf.Clamp(currentLane + value, -1, 1);
        transform.position = laneManager.transform.position + new Vector3(0, currentLane * laneOffset, 0);
    }

    public int GetPlayerCurrentLane()
    {
        return currentLane;
    }

    public void GiveMoney()
    {
        GameManager.Instance.gameState.AddMainCollectableValue(100);
    }
}
