using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Debug.Log("Instantiating ItemWorld prefab...");
        Transform transform = Instantiate(ItemAssets.Instance.PfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir() * 2.5f;
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir , item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir, ForceMode2D.Impulse);
        return itemWorld;
    }

    private Item item;

    private SpriteRenderer spriteRenderer;
    public TextMeshPro amtText;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on " + gameObject.name);
        }

        amtText = transform.Find("amtText").GetComponent<TextMeshPro>();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        // This line just fucking breaks everything (don't be surprised if sprites don't load when setting items)
        // spriteRenderer.sprite = item.GetSprite();
        if (item.amount > 1) amtText.SetText(item.amount.ToString());
        else amtText.SetText("");
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Debug.Log("Destroying: " + gameObject.name);
        Destroy(gameObject);
    }
}
