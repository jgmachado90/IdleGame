using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;
    
    public WorldScroller worldScroller;
    public LaneManager laneManager;
    public UIManager uiManager;
    
    public Player playerRef;

    private void Awake()
    {
        Instance = this;
    }

}
