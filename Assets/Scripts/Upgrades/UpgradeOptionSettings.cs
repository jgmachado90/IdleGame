using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Upgrade Settings", menuName = "Upgrade Settings")]
public class UpgradeOptionsSettings : ScriptableObject
{
    public string upgradeName;
    [TextArea(3, 10)] public List<string> description;
    public List<float> pricePerLevel;
    public float moneyToAppear;
    public int currentLevel;
    public bool purchased;

    public List<UpgradeOptionsSettings> upgradesInside;

    public UpgradeAction action;

    public void ResetStatus()
    {
        currentLevel = 0;
        purchased = false;
    }

}
