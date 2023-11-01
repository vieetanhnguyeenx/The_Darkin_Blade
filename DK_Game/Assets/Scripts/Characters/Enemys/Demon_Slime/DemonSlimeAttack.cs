using Assets.Scripts;
using UnityEngine;

public class DemonSlimeAttack : MonoBehaviour
{
    Animator animator;
    GameObject player;
    float distanceToPlayer;
    public float attackRange = 8f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        distanceToPlayer = Vector2.Distance(gameObject.transform.position, player.transform.position);
        animator.SetBool(AnimationStrings.isAttackRange, distanceToPlayer <= attackRange);
    }
}
