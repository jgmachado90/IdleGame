using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class HouseFactory : FactoryBase
{
    [SerializeField] private float minDistanceBetweenHouses;
    [SerializeField] private int specialHouseRate;
    [SerializeField] private float howFarSpawnHouses;
    private Transform lastHouse = null;
    private int houseCount = 0;
    
    [SerializeField] private WorldHouseSettings houseSettings;
    
    
    public override void InitializeFactory(FactoryManager _factoryManager)
    {
        base.InitializeFactory(_factoryManager);
        StartCoroutine(HousesSpawnsCoroutine());
    }
    
    public IEnumerator HousesSpawnsCoroutine()
    {
        while (true)
        {
            yield return null;
            while(!CanSpawnHouse()) yield return null;

            GameObject toSpawn = null;
            if (houseCount > specialHouseRate)
            {
                houseCount = 0;
                toSpawn = GetRandomHouse(houseSettings.SpecialHouses);
            }
            else
            {
                houseCount++;
                toSpawn = GetRandomHouse(houseSettings.GeneralHouses);
            }
            
            var spawnedHouse = Instantiate(toSpawn, toSpawn.transform.position, Quaternion.identity, transform);
            Debug.Log("House Spawned");
            spawnedHouse.transform.position = new Vector3(howFarSpawnHouses,spawnedHouse.transform.position.y , 0);
            lastHouse = spawnedHouse.transform;

            IWorldScrollable spawnedHouseScrollable = spawnedHouse.GetComponent<WorldObject>();
            factoryManager.Scroller.AddWorldScrollable(spawnedHouseScrollable);
       
        }
    }

    private GameObject GetRandomHouse(List<GameObject> houses)
    {
        int count = houses.Count;
        int index = Random.Range(0, count);
        return houses[index];
    }

    private bool CanSpawnHouse()
    {
        if (lastHouse == null) return true;
        float distance = Vector3.Distance(lastHouse.position, new Vector3(howFarSpawnHouses, 0, 0));
        if (distance > minDistanceBetweenHouses)
            return true;
        return false;

    }
}
