using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Pest Killer")]
public class PestKillerObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.PestKiller;
    }
}
