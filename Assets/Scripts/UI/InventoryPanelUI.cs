using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject items;

    private void Start()
    {
        background.SetActive(false);
        items.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            background.SetActive(!background.activeSelf);
            items.SetActive(!items.activeSelf);
        }
    }
}
