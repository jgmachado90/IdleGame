using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class CollectableObject : WorldObject, ICollectable
{
    private LaneManager laneManager;

    [SerializeField] protected CollectableSettings settings;

    public CollectableSettings Settings
    {
        get { return settings; }
        set { settings = value; }
    }
    public bool Collected { get; set; }
    
    public void Start()
    {
        laneManager = GameManager.Instance.laneManager;
        Collected = false;
        SpriteRenderer.sprite = settings.BeforeCollect;
    }
    public void Update()
    {
        if (transform.position.x < -20)
        {
           DestroyNotCollected();
        }
        if (Collected) return;
        TryToCollect();
    }

    private void TryToCollect()
    {
        if (!laneManager.IsInsideCollectArea(transform)) return;
        if (currentLane != GameManager.Instance.playerRef.GetPlayerCurrentLane()) return;
        Collect();
    }

    public virtual void Collect()
    {
        Collected = true;
        int minQuantity = (int)settings.CollectableQuantity.x;
        int maxQuantity = (int)settings.CollectableQuantity.y;
        int randomQuantity = UnityEngine.Random.Range(minQuantity, maxQuantity + 1);
        GameManager.Instance.gameState.AddMainCollectableValue(settings.Value * randomQuantity);
        CollectedFeedback(randomQuantity);
        if (settings.DestroyOnCollect)
        {
            GameManager.Instance.worldScroller.RemoveScrollable(this);
            Destroy(this.gameObject);
            return;
        }

        SpriteRenderer.sprite = settings.AfterCollect;
    }

    public void CollectedFeedback(int quantity)
    {
        GameObject feedbackPrefab = settings.CollectFeedback;
        GameManager.Instance.playerRef.GetComponent<CollectFeedback>().Invoke(feedbackPrefab, quantity);
    }

    public void DestroyNotCollected()
    {
        GameManager.Instance.worldScroller.RemoveScrollable(this);
        Destroy(gameObject);
    }
}