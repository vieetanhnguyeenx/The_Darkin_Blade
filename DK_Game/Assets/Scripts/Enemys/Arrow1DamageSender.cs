using Assets.Scripts.Characters;
using UnityEngine;

public class Arrow1DamageSender : MonoBehaviour
{
    Archer1Stats archerStats;

    // Start is called before the first frame update
    void Start()
    {
        archerStats = GetComponent<Archer1Stats>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ontrigger " + collision.tag);
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (collision.tag.Equals("Player"))
        {
            if (damageable != null)
            {
                Debug.Log("Not null");
                damageable.DealDamage(archerStats.Damage.Value);
            }
        }
    }
}
