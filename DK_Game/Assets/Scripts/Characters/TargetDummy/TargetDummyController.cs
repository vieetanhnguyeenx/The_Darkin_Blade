using Assets.Scripts.Characters;
using UnityEngine;

public class TargetDummyController : MonoBehaviour, IDamageable
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


    private void Awake()
    {
        CurrentHealth = MaxHealth.Value;
    }

    float IDamageable.Damage(float damageAmount)
    {
        if (IsAlive)
        {
            Debug.Log("dame deal to Dummy " + damageAmount);
            CurrentHealth -= damageAmount;
            return damageAmount;
        }
        return 0;
    }
}
