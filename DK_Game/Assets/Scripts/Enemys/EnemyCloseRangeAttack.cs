using Assets.Scripts;
using UnityEngine;

public class EnemyCloseRangeAttack : MonoBehaviour
{
    public float detectionRadius = 10.0f;
    public float attackRadius = 3.0f;
    public float moveSpeed = 5.0f;
    private Animator animator;
    private Transform player;
    private Vector3 initialPosition;

    [SerializeField] float health, maxHealth;
    [SerializeField] EnemyFloatingHealthBar healthBar;

    private float initHealth = 10f;
    private void Start()
    {
        health = initHealth; maxHealth = initHealth;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;
        healthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void Update()
    {
        EnemyBehaviour();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy is dead");
        ObjectPool objectPool = FindObjectOfType<ObjectPool>();
        objectPool.ReturnToPool(this.gameObject);
        health = initHealth;
        maxHealth = initHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    void EnemyBehaviour()
    {
        Debug.Log(health);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > detectionRadius)
        {
            // Case 1: Player not detected
            Debug.Log("Case 1: Player not detected");

            animator.SetBool(AnimationStrings.isMoving, true);
        }
        else if (distanceToPlayer <= detectionRadius && distanceToPlayer > attackRadius)
        {
            // Case 2: Player detected, move around initial position
            Debug.Log("Case 2: Player detected, move around initial position");

            animator.SetBool(AnimationStrings.isMoving, true);
            //Vector3 moveDirection = (initialPosition - transform.position).normalized;
            //transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
        else if (distanceToPlayer <= attackRadius)
        {
            // Case 3: Player detected, approach and attack
            Debug.Log("Case 3: Player detected, approach and attack");

            animator.SetBool(AnimationStrings.isMoving, true);
            Vector3 moveDirection = (player.position - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            // Turn to face the player
            if (player.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            if (distanceToPlayer < 2f)
            {
                // Switch to the attack animation
                animator.SetTrigger(AnimationStrings.attackTrigger);
            }
            else
            {
                animator.SetBool(AnimationStrings.isMoving, false);
            }
        }

        if (Vector3.Distance(transform.position, initialPosition) > 7.8f
            && Vector3.Distance(transform.position, initialPosition) < 8.3f)
        {
            // Case 4: Return to the initial position
            Debug.Log("Case 4: Return to the initial position");

            animator.SetBool(AnimationStrings.isMoving, true);
            Vector3 moveDirection = (initialPosition - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale *= -1;
        transform.localScale = localScale;
    }
}
