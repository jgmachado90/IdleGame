using UnityEngine;

public interface ICollectable
{
    public CollectableSettings Settings { get; set; }
    public bool Collected { get; set; }
    void Collect();
    void DestroyNotCollected();
}
