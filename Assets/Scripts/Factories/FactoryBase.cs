using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryBase : MonoBehaviour
{
    protected FactoryManager factoryManager;
    protected LaneManager laneManager;

    public virtual void InitializeFactory(FactoryManager _factoryManager)
    {
        factoryManager = _factoryManager;
        laneManager = GameManager.Instance.laneManager;
    }
}
