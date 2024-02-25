using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventsFactory : FactoryBase
{
    [SerializeField] private List<WorldEventSettings> eventSettings = new List<WorldEventSettings>();

    public override void InitializeFactory(FactoryManager _factoryManager)
    {
        base.InitializeFactory(_factoryManager);
        StartCoroutine(EventsSpawnCoroutine());
    }

    public IEnumerator EventsSpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            int random = Random.Range(-1, 2);
            float laneY = laneManager.transform.position.y + (laneManager.laneOffset * random);
            Vector3 position = new Vector3(factoryManager.HowFarToSpawnGameplayItems, laneY, 0);

            int currentWorld = factoryManager.CurrentWorld;
            
            int index = Random.Range(0, eventSettings[currentWorld].Events.Count);
            var prefab = eventSettings[currentWorld].Events[index].CollectablePrefab;
            
            GameObject spawned = Instantiate(prefab, position, quaternion.identity);
            WorldObject spawnedWO = spawned.GetComponent<WorldObject>();
            spawnedWO.SetLane(random);
            factoryManager.Scroller.AddWorldScrollable(spawned.GetComponent<IWorldScrollable>());
        }
    }
}
