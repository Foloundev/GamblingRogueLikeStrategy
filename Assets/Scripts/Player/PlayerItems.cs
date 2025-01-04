using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


public class PlayerItems : MonoBehaviour
{
    public Health health;
    public int healthValue;
    public TextMeshProUGUI healthText;

    public int carcassCount;
    public TextMeshProUGUI carcassText;

    public bool detectedDeath;
    public int carcassCountValue;
    public float deadX, deadY;

    private Inventory inventory;
    [SerializeField] private InventoryUI inventoryUI;


    private void Start()
    {
        inventory = new Inventory(UseItem);
        inventoryUI.SetInventory(inventory);
        inventoryUI.SetPlayer(this);

        healthValue = health.currentHealth;
        carcassCount = 0;
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            // Touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void UseItem(Item item)
    {
        switch(item.itemType) {
            case Item.ItemType.Remains:
                carcassCount++;
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Remains, amount = 1 });
                break;
            case Item.ItemType.Key:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.Key, amount = 1});
                break;
        }
    }

    private void Update()
    {
        if (detectedDeath)
        {
            detectedDeath = false;
        }
        health.currentHealth = healthValue;
        carcassText.text = "Carcasses: " + carcassCount.ToString();
        healthText.text = "Health: " + healthValue.ToString();
    }


}
