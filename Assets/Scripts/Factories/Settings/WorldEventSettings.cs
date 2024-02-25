using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldSettings", menuName = "WorldSettings")]
public class WorldEventSettings : ScriptableObject
{
    [Header("Events")] 
    [SerializeField] private List<CollectableSettings> events;
    public List<CollectableSettings> Events => events;
}
