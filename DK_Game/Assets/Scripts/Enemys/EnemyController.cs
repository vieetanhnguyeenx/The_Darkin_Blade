using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyAI
{
    private Transform playerTransform;
    private bool isTrackingPlayer;
    private bool isDefeated;
    [SerializeField]
    private int maxHealth = 5;
    private int currentHealth;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Initialize(transform);
    }

    public void Initialize(Transform enemyTransform)
    {
        isTrackingPlayer = false;
        isDefeated = false;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        UpdateAI();
    }

    public void UpdateAI()
    {
        if (!isDefeated)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer < 10f)
            {
                DetectPlayer(playerTransform);
            }
            else
            {
                LosePlayer();
            }
        }
    }

    public void DetectPlayer(Transform playerTransform)
    {
        isTrackingPlayer = true;
        Debug.Log("DetectPlayer");
    }

    public void LosePlayer()
    {
        isTrackingPlayer = false;
        Debug.Log("LosePlayer");
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isDefeated)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                isDefeated = true;
                Debug.Log("The enemy has been destroyed.");
            }
            else
            {
                Debug.Log($"The enemy has been attacked and has {currentHealth} health remaining.");
            }
        }
    }

    public void HitObstacle(Vector2 obstaclePosition)
    {
        // 
    }
}
