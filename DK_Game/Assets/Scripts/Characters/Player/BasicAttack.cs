using Assets.Scripts.Characters;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    Collider2D basicAttackColider;
    PlayerStats playerStats;
    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ontrigger " + collision.tag);
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Not null");
            damageable.Damage(playerStats.Damage.Value);
        }
    }
}
