using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableFactory : FactoryBase
{
    [SerializeField] private WorldCollectableSettings collectableSettings;

    public override void InitializeFactory(FactoryManager _factoryManager)
    {
        base.InitializeFactory(_factoryManager);
        StartCoroutine(CollectableSpawnCoroutine(collectableSettings.MainCollectable));
        foreach (var general in collectableSettings.GeneralCollectables)
        {
            StartCoroutine(CollectableSpawnCoroutine(general));    
        }
        
    }

    public IEnumerator CollectableSpawnCoroutine(CollectableSettings toSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(toSpawn.MinSpawnRate, toSpawn.MaxSpawnRate));
            int random = Random.Range(-1, 2);
            float laneY = laneManager.transform.position.y + (laneManager.laneOffset * random);
            Vector3 position = new Vector3(factoryManager.HowFarToSpawnGameplayItems, laneY, 0);

            int currentWorld = factoryManager.CurrentWorld;

            var prefab = toSpawn.CollectablePrefab;

            GameObject spawned = Instantiate(prefab, position, quaternion.identity);
            WorldObject spawnedWO = spawned.GetComponent<WorldObject>();
            spawnedWO.SetLane(random);
            factoryManager.Scroller.AddWorldScrollable(spawned.GetComponent<IWorldScrollable>());
        }
    }

}
