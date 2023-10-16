using UnityEngine;

public class AttackToEnemyTest : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage per attack
    private bool canAttack = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            canAttack = true;
            Debug.Log("Can Attack");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (canAttack)
                collision.gameObject.GetComponent<EnemyCloseRangeAttack>().TakeDamage(damageAmount);
        }
        Debug.Log("Can Attack 2");
    }
}
