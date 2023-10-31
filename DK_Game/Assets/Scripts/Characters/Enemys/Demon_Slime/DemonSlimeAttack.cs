using Assets.Scripts.Characters;
using UnityEngine;

public class DemonSlimeAttack : MonoBehaviour
{
    DemonSlimeStats demonSlimeStats;

    private void Awake()
    {
        demonSlimeStats = GetComponentInParent<DemonSlimeStats>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Ontrigger " + collision.tag);
        if (!collision.CompareTag("Player"))
            return;
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Not null");
            damageable.DealDamage(demonSlimeStats.Damage.Value);
            gameObject.GetComponentInParent<Enemysfx>().WeaponSound();
        }
    }
}
