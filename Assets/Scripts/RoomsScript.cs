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
        Gizmos.DrawCube(position, size);
    }

    public void DetectCollider()
    {
        foreach (Collider2D collider in Physics2D.OverlapBoxAll(transform.position, size, 0, 6))
        {
                Debug.Log("Changing Camera Pos");
                _camera.transform.position = transform.position;
        }
    }
}
