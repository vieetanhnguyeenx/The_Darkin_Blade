using Assets.Scripts.Characters;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    Collider2D basicAttackColider;
    PlayerStats playerStats;
    [SerializeField] public GameObject player;

    [SerializeField] public Vector2 knockback = Vector2.zero;
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
            damageable.DealDamage(playerStats.Damage.Value);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {

            Vector2 vector2knockbackVector = player.transform.localScale.x > 0 ? knockback : new Vector2(knockback.x * -1, knockback.y);
            Debug.Log(vector2knockbackVector);
            knockbackable.DealKnockback(vector2knockbackVector);
        }
    }
}
