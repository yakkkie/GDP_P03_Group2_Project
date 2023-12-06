using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSetItemType : MonoBehaviour
{
    private void Start()
    {
        // Assuming the sprite is assigned to the Image component
        Sprite sprite = GetComponentInChildren<Image>().sprite;

        // Determine the itemType based on the sprite
        ItemData.ItemType itemType = DetermineItemType(sprite);

        // Set the itemType in the ItemData component
        ItemData itemData = GetComponent<ItemData>();
        if (itemData != null)
        {
            itemData.itemType = itemType;
        }
    }

    private ItemData.ItemType DetermineItemType(Sprite sprite)
    {
        // Compare the sprite against known sprites for each ItemType
        if (sprite == ItemsAssets.Instance.aTierCatFood)
        {
            return ItemData.ItemType.TierAFood;
        }
        else if (sprite == ItemsAssets.Instance.bTierCatFood)
        {
            return ItemData.ItemType.TierBFood;
        }
        else if (sprite == ItemsAssets.Instance.cTierCatFood)
        {
            return ItemData.ItemType.TierCFood;
        }
        else if (sprite == ItemsAssets.Instance.cockroachSpray)
        {
            return ItemData.ItemType.CockSpray;
        }
        else if (sprite == ItemsAssets.Instance.electricSwatter)
        {
            return ItemData.ItemType.ElectricSwat;
        }
        else if (sprite == ItemsAssets.Instance.insectRepellent)
        {
            return ItemData.ItemType.InsectRepel;
        }
        else if (sprite == ItemsAssets.Instance.lizardKiller)
        {
            return ItemData.ItemType.LizzoKiller;
        }
        else if (sprite == ItemsAssets.Instance.normalSwatter)
        {
            return ItemData.ItemType.Swatt;
        }
        // Add more comparisons for other ItemTypes...

        // Default to a generic type if no match is found
        return ItemData.ItemType.Swatt;
    }
}
