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
        switch (item.itemType)
        {
            case Item.ItemType.TierAFood:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.TierAFood, amount = 1});
                break;
            case Item.ItemType.TierBFood:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.TierBFood, amount = 1});
                break;
            case Item.ItemType.TierCFood:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.TierCFood, amount = 1});
                break;
            case Item.ItemType.CockSpray:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.CockSpray, amount = 1});
                break;
            case Item.ItemType.ElectricSwat:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.ElectricSwat, amount = 1});
                break;
            case Item.ItemType.InsectRepel:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.InsectRepel, amount = 1});
                break;
            case Item.ItemType.LizzoKiller:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.LizzoKiller, amount = 1});
                break;
            case Item.ItemType.Swatt:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.Swatt, amount = 1});
                break;
        }
    }

}
