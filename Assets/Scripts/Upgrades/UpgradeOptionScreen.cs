using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeOptionScreen : MonoBehaviour
{
    [SerializeField] protected UpgradeOptionsSettings settings;

    public TextMeshProUGUI upgradeName;
    public TextMeshProUGUI description;
    public TextMeshProUGUI price;

    public Button buyButton;

    public Image backgroundColor;
    
    public void Initialize(UpgradeOptionsSettings newSettings)
    {
        settings = newSettings;
        upgradeName.text = newSettings.upgradeName + " LVL " + newSettings.currentLevel.ToString();
        if(newSettings.currentLevel < newSettings.description.Count)
            description.text = newSettings.description[newSettings.currentLevel];
        UpgradeOptionUpdate();
        if (newSettings.purchased)
        {
            backgroundColor.color = Color.yellow;
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "LVL MAX";
            price.text = " ";
            return;
        }
        price.text = newSettings.pricePerLevel[newSettings.currentLevel].ToString();
        
    }

    private void Update()
    {
        UpgradeOptionUpdate();
    }

    private void UpgradeOptionUpdate()
    {
        if (settings.purchased && !buyButton.interactable) return;
        if (settings.purchased && buyButton.interactable)
        {
            backgroundColor.color = Color.yellow;
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "LVL MAX";
        }
        else if (settings.pricePerLevel[settings.currentLevel] <= GameManager.Instance.gameState.PlayerMoney)
        {
            backgroundColor.color = Color.green;
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
            backgroundColor.color = Color.red;
        }
    }

    public void BuyOption()
    {
        GameManager.Instance.gameState.RemoveMainCollectableValue(settings.pricePerLevel[settings.currentLevel]);
        settings.currentLevel++;
        if(settings.pricePerLevel.Count == settings.currentLevel)
            settings.purchased = true;
        Initialize(settings);
    }
}
