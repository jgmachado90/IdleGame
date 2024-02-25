using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldSettings", menuName = "WorldCollectableSettings")]
public class WorldCollectableSettings : ScriptableObject
{
    [Header("Main Collectable")] 
    [SerializeField] private CollectableSettings mainCollectable;
    public CollectableSettings MainCollectable => mainCollectable;
    public float mainCollectableSpawnRate;
    
    [Header("GeneralCollectables")] 
    [SerializeField] private List<CollectableSettings> generalCollectables;
    public List<CollectableSettings> GeneralCollectables => generalCollectables;
    
    
 
   
}
