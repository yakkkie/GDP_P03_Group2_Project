using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType 
    {
        TierAFood,
        TierBFood,
        TierCFood,
        CockSpray,
        ElectricSwat,
        InsectRepel,
        LizzoKiller,
        Swatt
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.TierAFood: return ItemsAssets.Instance.aTierCatFood;
            case ItemType.TierBFood: return ItemsAssets.Instance.bTierCatFood;
            case ItemType.TierCFood: return ItemsAssets.Instance.cTierCatFood;
            case ItemType.CockSpray: return ItemsAssets.Instance.cockroachSpray;
            case ItemType.ElectricSwat: return ItemsAssets.Instance.electricSwatter;
            case ItemType.InsectRepel: return ItemsAssets.Instance.insectRepellent;
            case ItemType.LizzoKiller: return ItemsAssets.Instance.lizardKiller;
            case ItemType.Swatt: return ItemsAssets.Instance.normalSwatter;
        }
    }

    public bool isStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.TierAFood:
            case ItemType.TierBFood:
            case ItemType.TierCFood:
            case ItemType.CockSpray:
            case ItemType.ElectricSwat:
            case ItemType.InsectRepel:
            case ItemType.LizzoKiller:
            case ItemType.Swatt:
                return true;
        }
    }
}
