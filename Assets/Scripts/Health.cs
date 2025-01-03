using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    PlayerItems pItems;
    public GameObject player;
    public int currentHealth, maxHealth;
    // 0 = player
    // 1 = basic enemy
    public int type = 1;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    private void Start()
    {
        pItems = player.GetComponent<PlayerItems>();
    }

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(int amount, GameObject sender)
    {
        if (isDead) return;
        if (sender.layer == gameObject.layer) return;

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            if (sender.layer == 6)
            {
                pItems.detectedDeath = true;
                pItems.carcassCountValue = type;
                OnDeathWithReference?.Invoke(sender);
                isDead = true;
                Destroy(gameObject);
            }
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            Destroy(gameObject);
        }
    }
    private void Update()
    {
    }
}
