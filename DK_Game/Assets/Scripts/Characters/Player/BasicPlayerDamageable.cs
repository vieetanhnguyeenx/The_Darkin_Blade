using Assets.Scripts.Characters;
using UnityEngine;
using UnityEngine.Events;

public class BasicPlayerDamageable : MonoBehaviour
{
    [SerializeField] public UnityEvent<float> DealDamage;
    Collider2D basicAttackColider;
    PlayerStats playerStats;
    [SerializeField] public GameObject player;
    [SerializeField] public float BonusDamage;
    [SerializeField] public float BounusDamagePercentRate = 1f;

    [SerializeField] public Vector2 knockback = Vector2.zero;
    private void Awake()
    {
        playerStats = GetComponentInParent<PlayerStats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DealDamage.AddListener(player.GetComponent<ILifestealable>().LifeStealHeal);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Not null");
            float damageDealToTarget = damageable.DealDamage((playerStats.Damage.Value * BounusDamagePercentRate) + BonusDamage);
            DealDamage?.Invoke(damageDealToTarget);
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
