using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MainCollectableText;

    private GameState gameState;
    private void Start()
    {
        gameState = GameManager.Instance.gameState;
    }

    private void Update()
    {
        MainCollectableText.text = gameState.PlayerMoney.ToString("F2");
    }
}
