using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private CarcassShute carcassShute;
    [SerializeField] private InventoryUI inventoryUI;


    private void Start()
    {
        carcassShute = GameObject.Find("CarcassShute").GetComponent<CarcassShute>();
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
            Debug.Log("Converted");
            // Touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    public void UseItem(Item item)
    {
        switch(item.itemType) {
            case Item.ItemType.Remains:
                break;
            case Item.ItemType.Key:
                inventory.RemoveItem(new Item {itemType = Item.ItemType.Key, amount = 1});
                break;
        }
    }

    public bool isSold = false;

    private void Update()
    {

        if (carcassShute.isInRange && Input.GetKeyUp(KeyCode.E))
        {
            isSold = true;
            healthValue += carcassCount;
            inventory.RemoveItem(new Item { itemType = Item.ItemType.Remains, amount = carcassCount });
            carcassCount = 0;
        }


        if (inventory.carcassAdd != 0)
        {
            if (!isSold) carcassCount += inventory.carcassAdd;
            inventory.carcassAdd = 0;
            isSold = false;
        }
        if (detectedDeath)
        {
            detectedDeath = false;
        }
        health.currentHealth = healthValue;
        carcassText.text = "Carcasses: " + carcassCount.ToString();
        healthText.text = "Health: " + healthValue.ToString();
    }


}
