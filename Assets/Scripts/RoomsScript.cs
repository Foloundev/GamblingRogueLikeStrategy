using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsScript : MonoBehaviour
{
    private Vector3 size = new Vector3(19, 13, 0);
    [SerializeField] private GameObject _camera;
    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = transform.position;
        /*Gizmos.DrawWireSphere(position, radius);*/
        Gizmos.DrawWireCube(position, size);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            _camera.transform.position = new Vector3(transform.position.x,transform.position.y,_camera.transform.position.z); 
    }
}
