using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarcassShute : MonoBehaviour
{
    public bool isInRange = false;

    [SerializeField]
    private Transform circleOrigin;
    [SerializeField]
    private float radius;


    private void Start()
    {
        shuteText.text = "";
    }
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
        shuteText.text = "";
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            if (collider.gameObject.layer == 6)
            {
                ShuteFunction();
                isInRange = true;
                break;
            }
        }
    }

    public TextMeshProUGUI shuteText;

    public void ShuteFunction()
    {
        shuteText.text = "Press \"E\" to exchange carcasses";
    }
}
