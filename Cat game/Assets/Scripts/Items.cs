using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Items", menuName = "Items/Create New Items")]
public class Items : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite icon;
}
