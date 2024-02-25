using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldFactory : FactoryBase
{
    [SerializeField] private List<WorldSettings> worldSettings = new List<WorldSettings>();
    
    private List<WorldObject> streetObjects = new List<WorldObject>();
    private List<WorldObject> skyObjects = new List<WorldObject>();

    public override void InitializeFactory(FactoryManager _factoryManager)
    {
        base.InitializeFactory(_factoryManager);
        streetObjects = InitializeEnvironmentObject(worldSettings[factoryManager.CurrentWorld].Street);
        skyObjects = InitializeEnvironmentObject(worldSettings[factoryManager.CurrentWorld].Sky);
    }

    private List<WorldObject> InitializeEnvironmentObject(GameObject objToSpawn)
    {
        var spawnedObj = Instantiate(objToSpawn, transform.position, Quaternion.identity, transform);
        WorldObject spawnedWO = spawnedObj.GetComponent<WorldObject>();
        
        var newPosOffset = spawnedObj.transform.position + new Vector3(spawnedWO.GetSpriteWidth(), 0, 0);
        var spawnedObj2 = Instantiate(objToSpawn, newPosOffset, Quaternion.identity, transform);
        WorldObject spawnedWO2 = spawnedObj2.GetComponent<WorldObject>();
        
        factoryManager.Scroller.AddWorldScrollable(spawnedObj.GetComponent<IWorldScrollable>());
        factoryManager.Scroller.AddWorldScrollable(spawnedObj2.GetComponent<IWorldScrollable>());
        
        List<WorldObject> spawned = new List<WorldObject>();
        spawned.Add(spawnedWO);
        spawned.Add(spawnedWO2);
        
        return spawned;
    }
    private void Update()
    {
        ResetOutOfScreen(streetObjects);
        ResetOutOfScreen(skyObjects);
    }
    
    private void ResetOutOfScreen(List<WorldObject> objects)
    {
        WorldObject outOfScreen = null;
        foreach (var obj in objects)
        {
            if (obj.IsOutOfScreen())
                outOfScreen = obj;
        }
        if (outOfScreen == null) return;

        var mostRight = GetMostRight(objects);

        PutWorldObjectOnNextRight(outOfScreen, mostRight);
    }

    private static WorldObject GetMostRight(List<WorldObject> objects)
    {
        WorldObject mostRight = null;
        foreach (var obj in objects)
        {
            if (mostRight == null)
                mostRight = obj;
            
            else if (obj.transform.position.x > mostRight.transform.position.x)
                mostRight = obj;
        }
        return mostRight;
    }

    private void PutWorldObjectOnNextRight(WorldObject obj1, WorldObject obj2)
    {
        obj1.transform.position = obj2.transform.position + new Vector3(obj2.GetSpriteWidth(), 0, 0);
    }
}
