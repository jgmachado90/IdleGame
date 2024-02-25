using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Every Upgrade Settings", menuName = "Every Upgrade Settings")]
public class EveryUpgradeOptionsSettings : ScriptableObject
{
   public List<UpgradeOptionsSettings> EveryUpgrade;
}
