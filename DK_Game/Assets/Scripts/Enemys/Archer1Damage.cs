using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;

public class Archer1Damage : MonoBehaviour, IDamageable
{
    public bool isInvulnerable = false;
    EnemyFloatingHealthBar healthBar;
    Animator animator;
    Archer1Stats archer1Stats;
    private float _currentHealth;
    GameObject ObjectPool;
    private void Start()
    {
        archer1Stats = GetComponent<Archer1Stats>();
        healthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        _currentHealth = archer1Stats.MaxHealth.Value;
        healthBar.UpdateHealthBar(_currentHealth, archer1Stats.MaxHealth.Value);
        ObjectPool = GameObject.FindGameObjectWithTag("Archer2ObjectPool");
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
            ObjectPool.GetComponentInChildren<ObjectPool>().ReturnToPool(gameObject);
        }
    }


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log($"Archer2: {CurrentHealth}");
    }

    float IDamageable.DealDamage(float damageAmount)
    {
        if (IsAlive)
        {
            //Debug.Log("dame deal to Dummy " + damageAmount);
            CurrentHealth -= damageAmount;
            healthBar.UpdateHealthBar(_currentHealth, archer1Stats.MaxHealth.Value);
            return damageAmount;
        }
        return 0;
    }
}
