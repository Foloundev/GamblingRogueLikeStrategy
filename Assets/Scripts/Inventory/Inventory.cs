using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private Action<Item> useItemAction;
    private PlayerItems playerItems;



    public int carcassAdd;

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        /*AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Remains, amount = 3 });
        AddItem(new Item { itemType = Item.ItemType.KatanaFragment, amount = 1 });*/
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            if (item.itemType == Item.ItemType.Remains)
            {
                carcassAdd = item.amount;
            }
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            if (item.itemType == Item.ItemType.Remains)
            {
                carcassAdd = -item.amount;
            }
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
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
        }
        else
        {
            itemList.Remove(item);
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
