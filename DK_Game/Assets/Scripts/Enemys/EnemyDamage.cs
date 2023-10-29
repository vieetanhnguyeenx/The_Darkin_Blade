using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, IDamageable
{
    public bool isInvulnerable = false;
    EnemyFloatingHealthBar healthBar;

    [SerializeField] public CharaterStast MaxHealth;
    [SerializeField] public CharaterStast Damage;
    [SerializeField] public CharaterStast Armor;
    [SerializeField] public CharaterStast AttackSpeed;
    [SerializeField] public CharaterStast LifeSteal;

    [SerializeField]
    private float currentHealth;

    private void Start()
    {
        healthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        healthBar.UpdateHealthBar(currentHealth, MaxHealth.Value);
    }


    public float CurrentHealth
    {
        get { return currentHealth; }
        private set
        {
            currentHealth = value;
            // if  heath drop below 0, character is no longer alive
            if (currentHealth <= 0)
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
            GetComponent<Animator>().SetBool(AnimationStrings.isAlive, value);
            Debug.Log("Enemy death");
        }
    }


    private void Awake()
    {
        CurrentHealth = MaxHealth.Value;
    }

    float IDamageable.Damage(float damageAmount)
    {
        if (IsAlive)
        {

            if (!isInvulnerable)
            {
                currentHealth -= damageAmount;
                Debug.Log(currentHealth);
                //if (currentHealth <= MaxHealth.Value / 2f)
                //{
                //    GetComponent<Animator>().SetBool(AnimationStrings.isEnrage, true);
                //}

                if (currentHealth <= 0)
                {
                    isAlive = false;
                }
                healthBar.UpdateHealthBar(currentHealth, MaxHealth.Value);
                return damageAmount;
            }
        }
        return 0;
    }
}
