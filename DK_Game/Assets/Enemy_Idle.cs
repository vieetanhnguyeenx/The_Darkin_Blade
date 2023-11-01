using Assets.Scripts;
using UnityEngine;

public class Enemy_Idle : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 8f;
    public bool isLongRangeEnemy = false;
    Transform player;
    Rigidbody2D rb;
    Enemy enemy;
    float distanceToPlayer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
        //Debug.Log(player.gameObject.name);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtPlayer();
        //Debug.Log(Vector2.Distance(player.position, rb.position));
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
            animator.SetTrigger(AnimationStrings.attackTrigger);
        else
            animator.SetTrigger(AnimationStrings.IdleTrigger);
        if (!isLongRangeEnemy)
        {
            distanceToPlayer = Vector2.Distance(enemy.transform.position, player.transform.position);
            animator.SetBool(AnimationStrings.isAttackRange, distanceToPlayer <= attackRange);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(AnimationStrings.attackTrigger);
        animator.ResetTrigger(AnimationStrings.IdleTrigger);
    }
}
