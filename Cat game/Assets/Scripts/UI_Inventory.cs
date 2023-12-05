using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        
        float x = 0.5f;
        int y = 0;
        float itemSlotCellSize = 160f;

        foreach (Item item in inventory.GetItemList()) 
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            Button button = itemSlotRectTransform.GetComponent<Button>();

            itemSlotRectTransform.GetComponent<Button>().onClick.AddListener(() => HandleItemClick(item));



            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            } else {
                uiText.SetText("");
            }

            x++;
            if (x > 8)
            {
                x = 0;
                y++;
            }
        }
    }

    private void HandleItemClick(Item item)
    {
        Debug.Log("Item clicked: " + item.itemType);

        if (inventory != null)
        {
            inventory.UseItem(item);
        }
        else
        {
            Debug.LogError("Inventory not set in UI_Inventory script.");
        }
    }
}
