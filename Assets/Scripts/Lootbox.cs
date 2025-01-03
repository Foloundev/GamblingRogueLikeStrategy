using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootbox : MonoBehaviour
{
    public bool isInRange = false;

    // 1 = Health potion
    // 2 = Weapon fragment (check which one player doesn't have and give one of them)
    // 3 = Gold (to be used for skins or smthing)
    int[] lootTable = { };

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
        isInRange = false;
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            if (collider.gameObject.layer == 6)
            {
                isInRange = true;
                break;
            }
        }
    }
}
