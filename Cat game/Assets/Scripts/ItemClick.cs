using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemClick : MonoBehaviour, IPointerClickHandler
{
    private bool itemClicked = false;
    public EventClick eventClick;

   public void OnPointerClick(PointerEventData eventData)
    {
        if (!itemClicked)
        {
            ItemData itemData = GetComponent<ItemData>();

            if (itemData != null)
            {
                if (IsValidItem(itemData))
                {
                    // Your logic for a valid item click
                    Debug.Log("Item clicked for the first time!");
                    eventClick.SetCanInteract(true);
                }
                else
                {
                    Debug.Log("Invalid item clicked!");
                }

                itemClicked = true;
            }
            else
            {
                Debug.LogError("ItemData component not found!");
            }
        }
        else
        {
            Debug.Log("Item already clicked");
        }
    }

    private bool IsValidItem(ItemData itemData)
    {
        switch (itemData.itemType)
        {
            case ItemData.ItemType.TierAFood:
            case ItemData.ItemType.TierBFood:
            case ItemData.ItemType.TierCFood:
                return false; // These items are not valid for interaction

            case ItemData.ItemType.CockSpray:
                return true;

            default:
                return true; // All other items are valid
        }
    }
}