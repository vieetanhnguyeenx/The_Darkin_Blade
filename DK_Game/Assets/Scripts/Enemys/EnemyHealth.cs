using Assets.Scripts;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static float initHealth = 500f;
    public float health = initHealth;
    public float maxHealth = initHealth;
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    EnemyFloatingHealthBar healthBar;

    private void Start()
    {
        healthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool(AnimationStrings.isEnrage, true);
        }

        if (health <= 0)
        {
            Die();
        }
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
