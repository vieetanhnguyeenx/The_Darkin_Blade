using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneBossCreature : MonoBehaviour
{
    public List<Collider2D> BossCreatureDetectedColiders = new List<Collider2D>();
    public Collider2D targetCollision;
    private void OnTriggerExit2D(Collider2D collision)
    {
        BossCreatureDetectedColiders.Remove(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossCreatureDetectedColiders.Add(collision);
            targetCollision = collision;

        }
    }
}
