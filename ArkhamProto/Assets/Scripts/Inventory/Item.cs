using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword,
        HealthPotion,
        ManaPotion,
    }

    public ItemType itemtype;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemtype)
        {
            default:

            case ItemType.Sword:
                return ItemAssets.Instance.SwordSprite;

            case ItemType.HealthPotion:
                return ItemAssets.Instance.HealthPotionSprite;

            case ItemType.ManaPotion:
                return ItemAssets.Instance.ManaPotionSprite;
        }
    }

}
