using Assets.Scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyAI
{
    private Transform playerTransform;
    private GameObject playerGameObject;
    private bool isTrackingPlayer;
    private bool isDefeated;

    [SerializeField]
    private int maxHealth = 5;
    [SerializeField]
    private float moveSpeed = 2.0f;

    private Animator animator;
    private readonly float moveDistance = 1f;
    private float attackDistance = 3f;
    private int currentHealth;
    private Vector3 leftLimit;
    private Vector3 rightLimit;
    private bool overLimit = false;
    private bool movingRight = true;
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerGameObject.transform;
        animator = transform.GetComponent<Animator>();
        Initialize(transform);
    }

    public void Initialize(Transform enemyTransform)
    {
        isTrackingPlayer = false;
        isDefeated = false;
        currentHealth = maxHealth;

        initialPosition = transform.position;
        leftLimit = initialPosition - Vector3.right * 2f;
        rightLimit = initialPosition + Vector3.right * 2f;
        targetPosition = transform.position + Vector3.right * moveDistance;
        animator.SetBool(AnimationStrings.isMoving, true);
    }

    private void Update()
    {
        UpdateAI();
    }

    public void UpdateAI()
    {
        if (!isDefeated)
        {
            if (overLimit)
            {
                MoveToTarget(initialPosition);
                animator.SetBool(AnimationStrings.attackTrigger, false);
                float distanceAfterGoBack = Vector3.Distance(transform.position, initialPosition);
                if (distanceAfterGoBack > 0 && distanceAfterGoBack < 1f
                    || distanceAfterGoBack < 0 && distanceAfterGoBack > -1f)
                {
                    overLimit = false;
                    Flip();
                    return;
                }
            }
            else
            {
                float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
                float distanceToInitPosition = Vector3.Distance(transform.position, initialPosition);
                if (distanceToPlayer < attackDistance)
                {
                    AttackPlayer(distanceToInitPosition);
                }
                else if (distanceToPlayer < 10f && distanceToPlayer >= attackDistance)
                {
                    MoveAroundInitPosition();
                    DetectPlayer(playerTransform);
                }
                else
                {
                    LosePlayer();
                }
            }
        }
    }

    public void DetectPlayer(Transform playerTransform)
    {
        isTrackingPlayer = true;
        Debug.Log("DetectPlayer");
        animator.SetBool(AnimationStrings.isMoving, true);
    }

    public void LosePlayer()
    {
        isTrackingPlayer = false;
        Debug.Log("LosePlayer");
        animator.SetBool(AnimationStrings.isMoving, false);
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

    public void SendDamage(GameObject target)
    {
        Debug.Log("Enemies are attacking the player");
        FacingPlayer();
        animator.SetBool(AnimationStrings.attackTrigger, true);
    }

    public void MoveAroundInitPosition()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= rightLimit.x)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= leftLimit.x)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    private void AttackPlayer(float distanceToInitPosition)
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        if (directionToPlayer.magnitude > moveDistance)
        {
            // Move to a position 0.5f away from the player.
            targetPosition = playerTransform.position - directionToPlayer.normalized * moveDistance;
            if (distanceToInitPosition >= 5f)
            {
                overLimit = true;
                animator.SetBool(AnimationStrings.isMoving, true);
                return;
            }
            MoveToTarget(targetPosition);
        }
        else
        {
            SendDamage(playerGameObject);
        }
    }

    public void HitObstacle(Vector2 obstaclePosition)
    {
        // 
    }

    private void MoveToTarget(Vector3 targetPos)
    {
        if (transform.position.x <= targetPos.x)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        SendDamage(playerGameObject);
    }

    private void FacingPlayer()
    {
        Vector3 player = playerTransform.localScale;
        Vector3 enemy = transform.localScale;

        if (player.x - enemy.x < 0)
            Flip();
    }

    private void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
