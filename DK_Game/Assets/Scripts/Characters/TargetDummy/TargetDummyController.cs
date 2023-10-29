using Assets.Scripts.Characters;
using UnityEngine;

public class TargetDummyController : MonoBehaviour, IDamageable, IKnockbackable
{

    [SerializeField] public CharaterStast MaxHealth;
    [SerializeField] public CharaterStast Damage;
    [SerializeField] public CharaterStast Armor;
    [SerializeField] public CharaterStast AttackSpeed;
    [SerializeField] public CharaterStast LifeSteal;

    [SerializeField]
    private float currentHealth;
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
            Debug.Log("Target dummy death");
        }
    }

    Rigidbody2D rb;


    private void Awake()
    {
        CurrentHealth = MaxHealth.Value;
        rb = GetComponent<Rigidbody2D>();
    }

    float IDamageable.DealDamage(float damageAmount)
    {
        if (IsAlive)
        {
            Debug.Log("dame deal to Dummy " + damageAmount);
            CurrentHealth -= damageAmount;
            return damageAmount;
        }
        return 0;
    }

    public void DealKnockback(Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
