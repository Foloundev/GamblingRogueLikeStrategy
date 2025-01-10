using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentMovement : MonoBehaviour
{
    Rigidbody2D body;
    private Vector2 pointerInput, movementInput;

    [SerializeField] private InputActionReference movement, attack, pointerPosition;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    private WeaponParent weaponParent;

    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

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
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    
    void FixedUpdate()
    {
        
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
