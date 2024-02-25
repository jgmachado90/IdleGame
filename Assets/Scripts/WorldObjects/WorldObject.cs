using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour, IWorldScrollable
{
    protected SpriteRenderer spriteRenderer;
    protected int currentLane;

    public SpriteRenderer SpriteRenderer
    {
        get
        {
            if (spriteRenderer != null) return spriteRenderer;
            return spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    [SerializeField]
    private float scrollSpeed;
    public float ScrollSpeed {
        get
        {
            return scrollSpeed;
        }
        set
        {
            scrollSpeed = value;
        }
    }
    

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void Scroll()
    {
        var finalScrollSpeed = GameManager.Instance.playerRef.PlayerSpeed + ScrollSpeed;
        var newX = transform.position.x - finalScrollSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    public void Finished()
    {
        Destroy(gameObject);
    }

    public bool IsOutOfScreen()
    {
        var spriteMaxX = GetSpriteMaxX();
        
        float cameraHalfWidth = cam.orthographicSize * cam.aspect;
        float leftEdgeX = cam.transform.position.x - cameraHalfWidth;
        
        if (spriteMaxX < leftEdgeX) return true;
        return false;
    }

    public float GetSpriteMaxX()
    {
        return SpriteRenderer.transform.TransformPoint(spriteRenderer.sprite.bounds.max).x;
    }
    public float GetSpriteWidth()
    {
        return SpriteRenderer.sprite.bounds.size.x;
    }

    public void SetLane(int lane)
    {
        currentLane = lane;
    }
}
