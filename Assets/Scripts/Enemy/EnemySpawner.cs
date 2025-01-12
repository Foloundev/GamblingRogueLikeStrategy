using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Vector3 size = new Vector3(19, 13, 0);
    [SerializeField] private GameObject enemy;
    public RoomsScript roomScript;
    private int numEnemies;
    private bool wasPlayerHere = false;
    // Start is called before the first frame update
    void Start()
    {
        roomScript = GetComponentInParent<RoomsScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (roomScript.isPlayerInRoom == 1 && !wasPlayerHere)
            {
                numEnemies = Random.Range(10, 50)/10;
                for (int i = 0; i < numEnemies; i++)
                {
                    Debug.Log("Spawned Enemy");
                    Vector3 randomPos = new Vector3(Random.Range(-9f, 9f) + transform.position.x, Random.Range(-6f, 6f) + transform.position.y, 0f);
                    Instantiate(enemy, randomPos, Quaternion.identity);
                }
                roomScript.isPlayerInRoom = 2;
                wasPlayerHere = true;
            }
        }
    }
}
