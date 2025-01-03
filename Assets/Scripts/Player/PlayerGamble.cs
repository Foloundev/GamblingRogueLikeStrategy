using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGamble : MonoBehaviour
{
    public Lootbox lootbox;
    public GameObject LootboxUI;

    private PlayerItems pItems;

    public CarcassShute carcassShute;

    private void Start()
    {
        pItems = GetComponent<PlayerItems>();
    }

    private void Update()
    {
        if (lootbox.isInRange && Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("Open Lootbox");
            LootboxUI.SetActive(!LootboxUI.activeSelf);
        }

        if(carcassShute.isInRange && Input.GetKeyUp(KeyCode.E))
        {
            pItems.healthValue += pItems.carcassCount;
            pItems.carcassCount = 0;
        }
    }
}
