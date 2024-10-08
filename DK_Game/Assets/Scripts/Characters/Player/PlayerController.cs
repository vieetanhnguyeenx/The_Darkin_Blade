using Assets.Scripts;
using Assets.Scripts.Characters;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IDashingable
{

    [Header("Movment Variables")]
    [SerializeField] public float walkSpeed = 5f;
    public float jumpInpulse = 10f;

    private Rigidbody2D rb;
    private Animator animator;
    TouchingDirections touchingDirections;
    PlayerStats playerStats;
    PlayerDamage playerDamage;

    // Read from Player Input Action value -1 0 1
    private Vector2 moveInput;

    private bool isDashing = false;
    private float dashingTime = 0.1f;
    private TrailRenderer tr;

    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }


    public float CurrentMoveSpeed
    {
        get
        {
            if (CanMove)
            {
                if (IsMoving && !touchingDirections.IsOnWall)
                    return walkSpeed;
                else return 0;
            }
            else
            {
                return 0;
            }

        }
    }

    public bool _isFacingRight = true;


    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {
            // if _isFacingRight is set for new value is mean player is facing at the oppersite direction so we need to reverse the local scale
            if (_isFacingRight != value)
            {
                // reverse the local scale to make player facing the oppersite direction
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    public bool CanMove
    {
        get { return animator.GetBool(AnimationStrings.canMove); }
    }

    public bool IsAlive
    {
        get { return animator.GetBool(AnimationStrings.isAlive); }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        playerStats = GetComponent<PlayerStats>();
        playerDamage = GetComponent<PlayerDamage>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isDashing) return;
        if (!playerDamage.IsHit)
            rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (IsAlive)
        {
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }

    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            // Face the right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            // Face the left
            IsFacingRight = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // To do: Check Alive
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpInpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

    public void Dashing(float dashingPower)
    {
        StartCoroutine(Dash(dashingPower));
    }

    private IEnumerator Dash(float dashingPower)
    {
        int realLocalScale = 1;
        if (transform.localScale.x < 0)
        {
            realLocalScale = -1;
        }
        isDashing = true;
        float orginGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(realLocalScale * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = orginGravity;
        isDashing = false;

    }
}
