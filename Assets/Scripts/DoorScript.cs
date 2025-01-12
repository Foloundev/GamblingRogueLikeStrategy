using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private Transform circleOrigin;
    [SerializeField]
    private float radius;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void Update()
    {
        DetectCollider();
    }

    public void DetectCollider()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            if (collider.gameObject.layer == 6)
            {
                PlayerItems pItems;
                if(collider.gameObject.GetComponent<PlayerItems>() != null)
                {
                    pItems = collider.gameObject.GetComponent<PlayerItems>();
                    gameObject.SetActive(!pItems.usedKey);
                    pItems.usedKey = false;
                }
            }
        }
    }
}
