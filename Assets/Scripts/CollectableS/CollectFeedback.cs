using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectFeedback : MonoBehaviour
{
    [SerializeField] private Transform collectStartPos;
    [SerializeField] private Transform collectEndPos;
    
    [SerializeField] private Transform afterEndPos;

    [SerializeField] private float animDuration = 1f;
    [SerializeField] private AnimationCurve animCurve;

    [SerializeField] private List<GameObject> feedbackQueue;

    [SerializeField] private float betweenFeedbackDelay;
    private float lastFeedbackTime;
    
    public void Invoke(GameObject collectPrefab, int quantity)
    {
        for(int i = 0; i < quantity; i++)
            feedbackQueue.Add(collectPrefab);
    }

    private void Update()
    {
        if (Time.time < (lastFeedbackTime + betweenFeedbackDelay)) return;
        if (feedbackQueue.Count == 0) return;
        var collectedToShow = feedbackQueue[0];
        feedbackQueue.RemoveAt(0);
        StartCoroutine(CollectFeedbackAnimation(collectedToShow));
    }

    private IEnumerator CollectFeedbackAnimation(GameObject collectPrefab)
    {
        lastFeedbackTime = Time.time;
        var prefab = Instantiate(collectPrefab, collectStartPos.position, Quaternion.identity);
        var elapsedTime = 0f;
        while (true)
        {
            elapsedTime += Time.deltaTime;
            var t = Mathf.Clamp01(elapsedTime / animDuration);
            float lerpValue = animCurve.Evaluate(t);
            prefab.transform.position = Vector3.Lerp(collectStartPos.position, collectEndPos.position, lerpValue);
            if (Vector3.Distance(prefab.transform.position, collectEndPos.position) < 0.01f)
            {
                Destroy(prefab.gameObject);
                yield break;
            }
            yield return null;
        }
    }
}
