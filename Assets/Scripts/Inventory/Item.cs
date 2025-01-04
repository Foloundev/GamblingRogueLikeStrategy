using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        HealthPotion,
        KatanaFragment,
        KatanaSword,
        Key,
        Remains
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        Debug.Log("GetSprite called for itemType: " + itemType);
        if (ItemAssets.Instance == null)
        {
            Debug.LogError("ItemAssets.Instance is null.");
            return null;
        }
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.KatanaFragment: return ItemAssets.Instance.katanaFragmentSprite;
            case ItemType.KatanaSword: return ItemAssets.Instance.katanaSwordSprite;
            case ItemType.Remains: return ItemAssets.Instance.remainsSprite;
            case ItemType.Key: return ItemAssets.Instance.keySprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion: return true;
            case ItemType.KatanaFragment: return true;
            case ItemType.KatanaSword: return false;
            case ItemType.Remains: return true;
            case ItemType.Key: return true;
        }
    }
}
