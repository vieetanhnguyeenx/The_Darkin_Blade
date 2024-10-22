using Assets.Scripts;
using Assets.Scripts.Characters;
using System.Collections;
using UnityEngine;

public class Archer2Damage : MonoBehaviour, IDamageable, IKnockbackable
{
    public bool isInvulnerable = false;
    EnemyFloatingHealthBar healthBar;
    Animator animator;
    Archer2Stats archer2Stats;
    private float _currentHealth;
    GameObject ObjectPool;
    Rigidbody2D rb;
    public GameObject FloatingDamage;
    private void Start()
    {
        archer2Stats = GetComponent<Archer2Stats>();
        healthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        _currentHealth = archer2Stats.MaxHealth.Value;
        healthBar.UpdateHealthBar(_currentHealth, archer2Stats.MaxHealth.Value);
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
            if (!isAlive)
            {
                gameObject.GetComponentInChildren<Enemysfx>().PlayDeadSound();
            }
            if (ObjectPool != null)
                ObjectPool.GetComponentInChildren<ObjectPool>().ReturnToPool(gameObject);
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator WaitForSecond(float timer)
    {
        yield return new WaitForSeconds(timer);
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
            GameObject txtDamage = Instantiate(FloatingDamage, transform.position, Quaternion.identity);
            txtDamage.transform.GetChild(0).GetComponent<TextMesh>().text = $"-{damageAmount}";
            healthBar.UpdateHealthBar(_currentHealth, archer2Stats.MaxHealth.Value);
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
    //        CurrentHealth -= damageAmount;
    //        healthBar.UpdateHealthBar(_currentHealth, archer2Stats.MaxHealth.Value);
    //        return damageAmount;
    //    }
    //    return 0;
    //}

    public void DealKnockback(Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
