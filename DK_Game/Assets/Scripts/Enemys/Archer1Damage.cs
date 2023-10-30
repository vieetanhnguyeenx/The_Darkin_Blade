using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;

public class Archer1Damage : MonoBehaviour, IDamageable, IKnockbackable
{
    Rigidbody2D rb;
    public bool isInvulnerable = false;
    EnemyFloatingHealthBar healthBar;
    Animator animator;
    Archer1Stats archer1Stats;
    private float _currentHealth;
    GameObject ObjectPool;
    public GameObject FloatingDamage;
    private void Start()
    {
        archer1Stats = GetComponent<Archer1Stats>();
        healthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        _currentHealth = archer1Stats.MaxHealth.Value;
        healthBar.UpdateHealthBar(_currentHealth, archer1Stats.MaxHealth.Value);
        ObjectPool = GameObject.FindGameObjectWithTag("Archer1ObjectPool");
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


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //private void Update()
    //{
    //    Debug.Log($"Archer2: {CurrentHealth}");
    //}

    public float DealDamage(float damageAmount)
    {

        if (IsAlive)
        {
            //Debug.Log("dame deal to Dummy " + damageAmount);
            CurrentHealth -= damageAmount;
            //Instantiate(FloatingDamage, transform.position, Quaternion.identity);
            GameObject txtDamage = Instantiate(FloatingDamage, transform.position, Quaternion.identity);
            txtDamage.transform.GetChild(0).GetComponent<TextMesh>().text = $"-{damageAmount}";
            healthBar.UpdateHealthBar(_currentHealth, archer1Stats.MaxHealth.Value);
            gameObject.GetComponentInChildren<Enemysfx>().HurtSound();
            return damageAmount;
        }
        return 0;
    }

    //float IDamageable.DealDamage(float damageAmount)
    //{
    //    if (IsAlive)
    //    {
    //        //Debug.Log("dame deal to Dummy " + damageAmount);
    //        _currentHealth -= damageAmount;
    //        healthBar.UpdateHealthBar(_currentHealth, archer1Stats.MaxHealth.Value);
    //        return damageAmount;
    //    }
    //    return 0;
    //}

    public void DealKnockback(Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
