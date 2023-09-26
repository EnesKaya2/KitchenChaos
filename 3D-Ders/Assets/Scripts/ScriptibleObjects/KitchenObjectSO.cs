using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="KitchenObject", menuName = "SO/KitchenObjects")]
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;
    public string objectName;
    public Sprite sprite;
}
