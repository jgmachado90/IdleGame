using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldSettings", menuName = "WorldHouseSettings")]
public class WorldHouseSettings : ScriptableObject
{
    [Header("General Houses")]
    [SerializeField] private List<GameObject> generalHouses;
    public List<GameObject> GeneralHouses => generalHouses;
    
    [Header("Special Houses")]
    [SerializeField] private List<GameObject> specialHouses;
    public List<GameObject> SpecialHouses => specialHouses;
}