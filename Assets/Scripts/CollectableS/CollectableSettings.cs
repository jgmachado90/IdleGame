using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "Collectable Settings", menuName = "Collectable Settings")]
public class CollectableSettings : ScriptableObject
{
    [FormerlySerializedAs("name")] [SerializeField] private string collectableName;
    [SerializeField] private float value;
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private GameObject collectFeedback;
    [SerializeField] private Vector2 collectableQuantity;
    [SerializeField] private bool destroyOnCollect;

    [SerializeField] private Sprite beforeCollect;
    [SerializeField] private Sprite afterCollect;

    [SerializeField] private float minSpawnRate;
    [SerializeField] private float maxSpawnRate;
    
    public string CollectableName
    {
        get { return collectableName; }
    }

    public float Value
    {
        get
        {
            return value;
        }
    }

    public GameObject CollectablePrefab
    {
        get { return collectablePrefab; }
    }

    public GameObject CollectFeedback
    {
        get
        {
            return collectFeedback;
        }
    }

    public Vector2 CollectableQuantity
    {
        get
        {
            return collectableQuantity;
        }
    }

    public bool DestroyOnCollect
    {
        get
        {
            return destroyOnCollect;
        }
    }

    public Sprite BeforeCollect
    {
        get
        {
            return beforeCollect;
        }
    }

    public Sprite AfterCollect
    {
        get
        {
            return afterCollect;
        }
    }

    public float MinSpawnRate
    {
        get
        {
            return minSpawnRate;
        }
    }
    
    public float MaxSpawnRate
    {
        get
        {
            return maxSpawnRate;
        }
    }
}
  