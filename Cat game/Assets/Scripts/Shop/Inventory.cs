using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    // Event triggered when the inventory is updated
    public event System.Action InventoryUpdated;

    public void AddItem(Item item)
    {
        Item existingItem = items.Find(i => i.itemID == item.itemID);
        if (existingItem != null)
        {
            existingItem.quantity += item.quantity;
        }
        else
        {
            items.Add(item);
        }

        // Trigger the inventory updated event
        InventoryUpdated?.Invoke();
    }

    public int GetItemQuantity(int itemID)
    {
        Item item = items.Find(i => i.itemID == itemID);
        return item != null ? item.quantity : 0;
    }

    public bool UseItem(int itemID)
    {
        Item item = items.Find(i => i.itemID == itemID);
        if (item != null && item.quantity > 0)
        {
            item.quantity--;
            InventoryUpdated?.Invoke();
            return true;
        }
        return false;
    }
}

