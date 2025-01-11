using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentMovement : MonoBehaviour
{
    Rigidbody2D body;
    private Vector2 pointerInput, movementInput;

    [SerializeField] private InputActionReference movement, attack, pointerPosition;

    Vector2 move;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    private WeaponParent weaponParent;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    public Animator animator;

    private void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
      
    }

    public void PerformAttack()
    {
        weaponParent.Attack();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //pointerInput = GetPointerInput();
       // movementInput = move.action.ReadValue<Vector2>().normalized;
        weaponParent.PointerPosition = pointerInput;
        // Gives a value between -1 and 1
        move.x = Input.GetAxisRaw("Horizontal"); // -1 is left
        move.y = Input.GetAxisRaw("Vertical"); // -1 is down

        animator.SetFloat("Vertical", move.y);
    }

    
    void FixedUpdate()
    {
        
        if (move.x != 0 && move.y != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            move.x *= moveLimiter;
            move.y *= moveLimiter;
        }

        body.velocity = new Vector2(move.x * runSpeed, move.y * runSpeed);
    }
}
