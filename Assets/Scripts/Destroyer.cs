using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClosedRoom") || collision.gameObject.CompareTag("SpawnPoint"))
        {
            Debug.Log("Destroyed SpawnPoint");
            Destroy(collision.gameObject);
        }
    }
}
