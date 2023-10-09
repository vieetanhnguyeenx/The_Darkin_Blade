using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D)   )]
public class PlayerController : MonoBehaviour
{
    [Header("Movment Variables")]
    [SerializeField] public float walkSpeed = 5f;

    private Rigidbody2D rb;

    // Read from Player Input Action value -1 0 1
    private Vector2 moveInput;

    // 
    public bool IsMoving { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
    }
}
