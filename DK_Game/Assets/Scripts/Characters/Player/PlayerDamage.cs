using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamageable, ILifestealable, IPunishable, IDashingable
{
    PlayerStats playerStats;
    Animator animator;
    PlayerFloatingHealthBar healthBar;
    [SerializeField] private float _currentHealth;
    [SerializeField]
    private GameObject FloatingDamage;
    [SerializeField]
    private GameObject FloatingHealthSeal;
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
    public float invincibilityTime = 3f;
    private bool _isAlive = true;
    private PlayerAbilityW playerAbilityW;

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
        GameObject PlayerInfo = GameObject.FindGameObjectWithTag("PlayerInfo");
        healthBar = PlayerInfo.GetComponentInChildren<PlayerFloatingHealthBar>();
        healthBar.UpdateHealthBar(_currentHealth, playerStats.MaxHealth.Value);
        playerAbilityW = GetComponent<PlayerAbilityW>();
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
        Debug.Log($"Curent Health: {CurrentHealth}");
    }

    public float DealDamage(float damageAmount)
    {
        if (_isAlive && !isInvincible)
        {
            CurrentHealth -= damageAmount;
            isInvincible = true;
            // Todo caculate damage
            GameObject txtDamage = Instantiate(FloatingDamage, transform.position, Quaternion.identity);
            txtDamage.transform.GetChild(0).GetComponent<TextMesh>().text = $"-{damageAmount}";
            healthBar.UpdateHealthBar(CurrentHealth, playerStats.MaxHealth.Value);
            return damageAmount;
        }
        return 0;
    }

    public void LifeStealHeal(float damageDeal)
    {
        float healthStealed = damageDeal * playerStats.LifeSteal.Value;
        CurrentHealth += healthStealed;
        GameObject txtDamage = Instantiate(FloatingHealthSeal, transform.position, Quaternion.identity);
        txtDamage.transform.GetChild(0).GetComponent<TextMesh>().text = $"+{healthStealed}";
        healthBar.UpdateHealthBar(CurrentHealth, playerStats.MaxHealth.Value);

    }

    public void Punish(float damageDeal)
    {
        if (playerAbilityW.IsActivated)
        {
            float punishDamage = playerStats.MaxHealth.Value * playerAbilityW.punishPercentRate;
            CurrentHealth -= punishDamage;

        }
    }

    public void Dashing(float dashingPower)
    {
        Debug.Log("Dashing ");
        isInvincible = true;
    }
}
