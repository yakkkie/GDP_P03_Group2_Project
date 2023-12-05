using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public event EventHandler OnItemListChanged;

    private List <Item> itemList;
    private Action<Item> useItemAction;
    
    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        AddItem(new Item {itemType = Item.ItemType.TierAFood, amount = 1});     
        AddItem(new Item {itemType = Item.ItemType.TierBFood, amount = 1}); 
        AddItem(new Item {itemType = Item.ItemType.TierCFood, amount = 1}); 
        AddItem(new Item {itemType = Item.ItemType.ElectricSwat, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.CockSpray, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.InsectRepel, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.LizzoKiller, amount = 1});
        AddItem(new Item {itemType = Item.ItemType.Swatt, amount = 1}); 
        AddItem(new Item {itemType = Item.ItemType.Swatt, amount = 1}); 
        AddItem(new Item {itemType = Item.ItemType.Swatt, amount = 1}); 
        AddItem(new Item {itemType = Item.ItemType.Swatt, amount = 1}); 

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        if (item.isStackable())
        {
            bool itemAlreadyInIventory = false;
            foreach(Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount; 
                    itemAlreadyInIventory = true;
                }
            }
            if (!itemAlreadyInIventory)
            {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        if (item.isStackable())
        {
            Item itemInInventory = null;
            foreach(Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount; 
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        } else {
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
