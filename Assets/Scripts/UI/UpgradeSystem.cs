using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private EveryUpgradeOptionsSettings settings;

    [SerializeField] private GameObject optionPrefab;

    [SerializeField] private Transform optionParent;
    [SerializeField] private Transform firstOptionPos;

    [SerializeField] private List<GameObject> optionList;

    public void Start()
    {
        foreach (var upgrade in settings.EveryUpgrade)
        {
            upgrade.ResetStatus();
        }
    }


    public void Invoke()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        CreateOptions();
    }

    private void CreateOptions()
    {
        foreach (var opt in optionList)
        {
            Destroy(opt.gameObject);
        }

        optionList.Clear();

        foreach (var upgrade in settings.EveryUpgrade)
        {
            var newOption = Instantiate(optionPrefab, firstOptionPos.position, quaternion.identity, optionParent);

            UpgradeOptionScreen newOptionScreen = newOption.GetComponent<UpgradeOptionScreen>();
            newOptionScreen.Initialize(upgrade);

            optionList.Add(newOption);
        }
    }
}