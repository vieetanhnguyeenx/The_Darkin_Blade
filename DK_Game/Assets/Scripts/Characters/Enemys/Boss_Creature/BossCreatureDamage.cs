using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;

public class BossCreatureDamage : MonoBehaviour, IDamageable, IKnockbackable
{
    EnemyFloatingHealthBar healthBar;
    public bool isInvulnerable = false;
    Animator animator;
    BossCreatureStats bossCreatureStats;
    private float _currentHealth;
    GameObject ObjectPool;
    Rigidbody2D rb;
    public GameObject FloatingDamage;

    DetectionZoneBossCreature attackZone;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attackZone = GetComponentInChildren<DetectionZoneBossCreature>();
    }

    private void Start()
    {
        bossCreatureStats = GetComponent<BossCreatureStats>();
        healthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        _currentHealth = bossCreatureStats.MaxHealth.Value;
        healthBar.UpdateHealthBar(_currentHealth, bossCreatureStats.MaxHealth.Value);
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
        HasTarget = attackZone.BossCreatureDetectedColiders.Count > 0;
        if (_currentHealth < (bossCreatureStats.MaxHealth.Value / 2))
        {
            animator.SetBool(AnimationStrings.isEnrage, true);
        }
    }
    public float DealDamage(float damageAmount)
    {
        if (IsAlive)
        {
            //Debug.Log("dame deal to Dummy " + damageAmount);
            animator.SetTrigger(AnimationStrings.isHit);
            CurrentHealth -= damageAmount;
            GameObject txtDamage = Instantiate(FloatingDamage, transform.position, Quaternion.identity);
            txtDamage.transform.GetChild(0).GetComponent<TextMesh>().text = $"-{damageAmount}";
            healthBar.UpdateHealthBar(_currentHealth, bossCreatureStats.MaxHealth.Value);
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

    public void Attack()
    {
        if (attackZone.targetCollision == null)
            return;
        IDamageable damageable = attackZone.targetCollision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Not null");
            damageable.DealDamage(bossCreatureStats.Damage.Value);
            gameObject.GetComponentInChildren<Enemysfx>().WeaponSound();
        }
    }

    public void Attack2()
    {
        if (attackZone.targetCollision == null)
            return;
        IDamageable damageable = attackZone.targetCollision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Not null");
            damageable.DealDamage(bossCreatureStats.Damage.Value + 50);
            gameObject.GetComponentInChildren<Enemysfx>().WeaponSound();
        }
    }
}