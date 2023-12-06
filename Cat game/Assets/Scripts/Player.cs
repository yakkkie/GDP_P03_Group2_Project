using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    public UI_Inventory uiInventory;

    private void Awake()
    {
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
    }

    private void UseItem(Item item)
{
    // Check if the item is the correct type before performing the action
    if (IsValidItem(item))
    {
        switch (item.itemType)
        {
            case Item.ItemType.TierAFood:
            case Item.ItemType.TierBFood:
            case Item.ItemType.TierCFood:
                break;
            case Item.ItemType.CockSpray:
                // Handle Cockroach Spray
                Debug.Log("Used Cockroach Spray!");
                break;
            case Item.ItemType.ElectricSwat:
                // Handle Electric Swat
                break;
            // ... handle other item types ...
            default:
                // Handle generic usage for other item types
                Debug.Log($"Used {item.itemType}!");
                break;
        }

        // Remove the used item from the inventory
        inventory.RemoveItem(item);
    }
    else
    {
        // Remove the used item from the inventory
        inventory.RemoveItem(item);
        Debug.Log("Item has been removed!");
    }
}

    public static bool IsValidItem(Item item)
    {
        // Implement your logic to check if the item is valid for interaction
        // For example, you can compare the item type or name
        return item.itemType == Item.ItemType.CockSpray;
    }

}
