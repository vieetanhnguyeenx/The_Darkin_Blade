
using Assets.Scripts;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groudHitDistance = 0.05f;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    CapsuleCollider2D touchingCol;
    Animator animator;

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }
    [SerializeField]
    private bool _isGround;
    public bool IsGround
    {
        get
        {
            return _isGround;
        }
        private set
        {
            _isGround = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
    }

    private void FixedUpdate()
    {
        IsGround = touchingCol.Cast(Vector2.down, castFilter, groundHits, groudHitDistance) > 0;
    }
}
