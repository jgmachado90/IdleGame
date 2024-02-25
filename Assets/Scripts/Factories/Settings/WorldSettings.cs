using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldSettings", menuName = "WorldSettings")]
public class WorldSettings : ScriptableObject
{
    [Header("World")]
    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject garden;
    [SerializeField] private GameObject street;

    public GameObject Sky => sky;
    public GameObject Garden => garden;
    public GameObject Street => street;
}