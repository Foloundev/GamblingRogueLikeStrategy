using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int OpeningDir;
    private RoomTemplates templates;
    private int randInt;
    public bool spawned = false;

    private void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .15f);
    }

    private void Spawn()
    {
        if (!spawned)
        {
            if (OpeningDir == 1)
            {
                //dolu
                randInt = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[randInt], transform.position, Quaternion.identity);

            }
            else if (OpeningDir == 2)
            {
                //gore
                randInt = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[randInt], transform.position, Quaternion.identity);

            }
            else if (OpeningDir == 3)
            {
                //lqvo
                randInt = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[randInt], transform.position, Quaternion.identity);

            }
            else if (OpeningDir == 4)
            {
                //dqsno
                randInt = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[randInt], transform.position, Quaternion.identity);

            }
            spawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(CompareTag("Spawnpoint"));
        if (other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
