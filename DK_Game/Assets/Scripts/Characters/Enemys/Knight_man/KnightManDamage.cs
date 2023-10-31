using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;

public class KnightManDamage : MonoBehaviour, IDamageable, IKnockbackable
{
    EnemyFloatingHealthBar healthBar;
    public bool isInvulnerable = false;
    Animator animator;
    KnightManStats knightManStats;
    private float _currentHealth;
    GameObject ObjectPool;
    Rigidbody2D rb;
    public GameObject FloatingDamage;

    DetectionZoneKnightMan attackZone;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attackZone = GetComponentInChildren<DetectionZoneKnightMan>();
    }

    private void Start()
    {
        knightManStats = GetComponent<KnightManStats>();
        healthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        _currentHealth = knightManStats.MaxHealth.Value;
        healthBar.UpdateHealthBar(_currentHealth, knightManStats.MaxHealth.Value);
        ObjectPool = GameObject.FindGameObjectWithTag("KnightManObjectPool");
    }

    public bool _hasTarget = false;
    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    private void Update()
    {
        HasTarget = attackZone.KnightManDetectedColiders.Count > 0;

    }
    public float DealDamage(float damageAmount)
    {
        if (IsAlive)
        {
            //Debug.Log("dame deal to Dummy " + damageAmount);
            CurrentHealth -= damageAmount;
            GameObject txtDamage = Instantiate(FloatingDamage, transform.position, Quaternion.identity);
            txtDamage.transform.GetChild(0).GetComponent<TextMesh>().text = $"-{damageAmount}";
            healthBar.UpdateHealthBar(_currentHealth, knightManStats.MaxHealth.Value);
            gameObject.GetComponentInChildren<Enemysfx>().HurtSound();
            return damageAmount;
        }
        return 0;
    }

    public void DealKnockback(Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    public float CurrentHealth
    {
        get { return _currentHealth; }
        private set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool isAlive = true;
    public bool IsAlive
    {
        get { return isAlive; }
        private set
        {
            isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("Enemy death");
            if (ObjectPool != null)
                ObjectPool.GetComponentInChildren<ObjectPool>().ReturnToPool(gameObject);
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
