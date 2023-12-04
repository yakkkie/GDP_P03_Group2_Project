using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Items> inventory = new List<Items>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    private bool hasUIInstantiated = false;

    void Start()
    {
        inventory.Clear();
        AddItem(Resources.Load<Items>("ATierCatFood"));
        AddItem(Resources.Load<Items>("BTierCatFood"));
        AddItem(Resources.Load<Items>("CTierCatFood"));
        AddItem(Resources.Load<Items>("CockroachSpray"));
        AddItem(Resources.Load<Items>("ElectricSwatter"));
        AddItem(Resources.Load<Items>("InsectRepellent"));
        AddItem(Resources.Load<Items>("LizardKiller"));
        AddItem(Resources.Load<Items>("NormalSwatter"));
    }

    public void DisplayInventory()
    {
        if (!hasUIInstantiated)
        {
            foreach (var item in inventory)
            {
                GameObject itemDisplay = Instantiate(InventoryItem, ItemContent);
                itemDisplay.GetComponentInChildren<Image>().sprite = item.icon;
            }
            hasUIInstantiated = true;
        }
    }

    public void AddItem(Items item)
    {
        inventory.Add(item);
        Debug.Log(item.itemName + " added to inventory.");
    }

    public void UseItem(Items item)
    {
        if (inventory.Contains(item))
        {
            Debug.Log("Using " + item.itemName);
            inventory.Remove(item);
        }
        else
        {
            Debug.Log("Item not found in inventory.");
        }
    }
}
