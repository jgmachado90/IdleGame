using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    [SerializeField] private int currentWorld;
    public int CurrentWorld
    {
        get { return currentWorld; }
    }
    
    [SerializeField] private float howFarToSpawnGameplayItems;

    public float HowFarToSpawnGameplayItems
    {
        get { return howFarToSpawnGameplayItems; }
    }
    
    [SerializeField] private WorldScroller scroller;

    public WorldScroller Scroller
    {
        get { return scroller; }
    }
    
    [SerializeField] private WorldFactory worldFactory;
    [SerializeField] private HouseFactory houseFactory;
    [SerializeField] private CollectableFactory collectableFactory;
    [SerializeField] private EventsFactory eventsFactory;

    private void Start()
    {
        if(worldFactory != null)
            worldFactory.InitializeFactory(this);
        if(houseFactory != null)
            houseFactory.InitializeFactory(this);
        if(collectableFactory != null)
            collectableFactory.InitializeFactory(this);
        if(eventsFactory != null)
            eventsFactory.InitializeFactory(this);
    }
}
