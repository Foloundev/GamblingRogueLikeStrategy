using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("ItemAssets instance initialized.");
        }
        else
        {
            Debug.LogError("Multiple instances of ItemAssets detected!");
            Destroy(gameObject); // Optionally destroy duplicates
            return;
        }
    }

    public Transform PfItemWorld;

    public Sprite katanaFragmentSprite;
    public Sprite katanaSwordSprite;
    public Sprite healthPotionSprite;
    public Sprite remainsSprite;
    public Sprite keySprite;
}
