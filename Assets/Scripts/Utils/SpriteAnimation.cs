using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteAnimation : MonoBehaviour
{ 
    [FormerlySerializedAs("renderer")] [SerializeField] private SpriteRenderer spriteRenderer;
   [SerializeField] List<Sprite> sprites = new List<Sprite>();
   [SerializeField] private float delay;
       
    void Start()
    {
        StartCoroutine(SpriteAnimationCoroutine());
    }

    public IEnumerator SpriteAnimationCoroutine()
    {
        int currentIndex = 0;
        int maxIndex = sprites.Count - 1;
        while (true)
        {
            spriteRenderer.sprite = sprites[currentIndex];
            yield return new WaitForSeconds(delay);
            currentIndex = currentIndex == maxIndex ? 0 : currentIndex + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
