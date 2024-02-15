using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[3, 2];
    public float coins;
    public Text CoinsTXT;
    public Inventory inventory;

    public Text swatterQuantityText;

    void Start()
    {
        CoinsTXT.text = "Coins: " + coins.ToString();
        inventory = FindObjectOfType<Inventory>();

        // ID's
        shopItems[1, 1] = 1;

        // Price
        shopItems[2, 1] = 10;

        // Quantity
        shopItems[3, 3] = 0;
    }

    void Update()
    {
        UpdateSwatterQuantity();
    }

    public void Buy()
    {
        GameObject ButtonRef = EventSystem.current.currentSelectedGameObject;

        int itemID = ButtonRef.GetComponent<ButtonInfo>().ItemID;
        int itemPrice = shopItems[2, itemID];

        if (coins >= itemPrice)
        {
            coins -= itemPrice;
            CoinsTXT.text = "Coins: " + coins.ToString();
            Debug.Log("Item Bought!");

            Item item = new Item();
            item.itemID = itemID;
            item.itemName = "Item Name"; // Set appropriate item name
            item.itemPrice = itemPrice;
            item.quantity = 1; // You can set quantity as needed
            // Set item icon if needed

            inventory.AddItem(item);
        }
    }

    void UpdateSwatterQuantity()
    {
        // Get the quantity of swatters from the inventory
        int swatterQuantity = inventory.GetItemQuantity(1); // Assuming swatter's itemID is 1

        // Update the quantity text in the UI
        swatterQuantityText.text = swatterQuantity.ToString();
    }
}
