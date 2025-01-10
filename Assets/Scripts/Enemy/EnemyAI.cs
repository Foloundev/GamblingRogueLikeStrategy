using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack;

    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistThreshold = 3f, attackDistThreshold = 0.8f;
    [SerializeField] private float attackDelay = 1, passedTime = 1;

    void Update()
    {
        if (player == null)
        {
            return;
        }
        else
        {
            float distance = Vector2.Distance(player.position, transform.position);
            if (distance < chaseDistThreshold) {
                OnPointerInput?.Invoke(player.position);
                if (distance < attackDistThreshold)
                {
                    OnMovementInput?.Invoke(Vector2.zero);
                    if(passedTime >= attackDelay)
                    {
                        passedTime = 0;
                        OnAttack?.Invoke();
                    }
                }
                else
                {
                    // enemy goni
                    Vector2 direction = player.position - transform.position;
                    OnMovementInput?.Invoke(direction.normalized);
                }
            }
            if(passedTime < attackDelay)
            {
                passedTime += Time.deltaTime;
            }
        }
    }
}
