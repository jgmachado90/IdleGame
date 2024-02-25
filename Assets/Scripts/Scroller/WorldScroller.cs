using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public List<IWorldScrollable> worldScollables = new List<IWorldScrollable>();
    
    public void AddWorldScrollable(IWorldScrollable newScrollable)
    {
        worldScollables.Add(newScrollable);
    }
    private void FixedUpdate()
    {
        foreach (var scrollable in worldScollables)
        {
            scrollable.Scroll();
        }
    }

    public void RemoveScrollable(IWorldScrollable scrollable)
    {
        worldScollables.Remove(scrollable);
    }
}
