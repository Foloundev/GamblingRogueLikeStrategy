using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGamble : MonoBehaviour
{
    public Lootbox lootbox;
    public GameObject LootboxUI;

    private PlayerItems pItems;


    private Inventory inventory;
    public CarcassShute carcassShute;

    private void Start()
    {
        pItems = GetComponent<PlayerItems>();

        inventory = new Inventory(pItems.UseItem);
    }

    private void Update()
    {
        if (lootbox.isInRange && Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("Open Lootbox");
            LootboxUI.SetActive(!LootboxUI.activeSelf);
        }
    }
}
