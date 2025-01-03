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


    void Start()
    {
        healthValue = health.currentHealth;
        carcassCount = 0;
    }

    private void Update()
    {
        if (detectedDeath)
        {
            Debug.Log("Enemy died");
            carcassCount += carcassCountValue;
            detectedDeath = false;
        }
        health.currentHealth = healthValue;
        carcassText.text = "Carcasses: " + carcassCount.ToString();
        healthText.text = "Health: " + healthValue.ToString();
    }


}
