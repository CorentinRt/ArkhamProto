using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    private List<Item> _itemList;

    public Inventory()
    {
        _itemList = new List<Item>();

        AddItem(new Item { itemtype = Item.ItemType.Sword, amount = 1});
        AddItem(new Item { itemtype = Item.ItemType.ManaPotion, amount = 1});
        AddItem(new Item { itemtype = Item.ItemType.HealthPotion, amount = 1});
        AddItem(new Item { itemtype = Item.ItemType.Sword, amount = 1});
        AddItem(new Item { itemtype = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.ManaPotion, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.HealthPotion, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.ManaPotion, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.HealthPotion, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.Sword, amount = 1 });
    }

    public void AddItem(Item item)
    {
        _itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return _itemList;
    }
}
