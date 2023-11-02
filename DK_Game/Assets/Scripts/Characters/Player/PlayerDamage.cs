using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamageable, ILifestealable
{
    PlayerStats playerStats;
    Animator animator;

    [SerializeField] private float _currentHealth;

    [SerializeField]
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            if (value >= playerStats.MaxHealth.Value)
            {
                _currentHealth = playerStats.MaxHealth.Value;
            }
            else
            {
                _currentHealth = value;
            }
            // if  heath drop below 0, character is no longer alive
            if (_currentHealth <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool isInvincible = false;
    private float timeSinceHit = 0;
    [SerializeField]
    public float invincibilityTime = 1f;

    private bool _isAlive = true;

    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set" + value);
        }
    }

    public bool IsHit
    {
        get
        {
            return animator.GetBool(AnimationStrings.isHit);
        }

        private set
        {
            animator.SetBool(AnimationStrings.isHit, value);
        }
    }

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
        _currentHealth = playerStats.MaxHealth.Value;
    }


    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    }

    public float DealDamage(float damageAmount)
    {
        if (_isAlive && !isInvincible)
        {
            CurrentHealth -= damageAmount;
            isInvincible = true;
            // Todo caculate damage
            return damageAmount;
        }
        return 0;
    }

    public void LifeStealHeal(float damageDeal)
    {
        float healthStealed = damageDeal * playerStats.LifeSteal.Value;
        CurrentHealth += healthStealed;
        Debug.Log("Lifesteal " + healthStealed);
    }
}
