using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private float playerMoney;
    public float PlayerMoney
    { get{ return playerMoney; } }


    public void RemoveMainCollectableValue(float value)
    {
        playerMoney -= value;
    }    
    

    public void AddMainCollectableValue(float value)
    {
        playerMoney += value;
    }
}
