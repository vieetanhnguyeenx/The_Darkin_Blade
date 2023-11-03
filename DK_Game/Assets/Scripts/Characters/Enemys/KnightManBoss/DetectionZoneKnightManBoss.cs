using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneKnightManBoss : MonoBehaviour
{
    public List<Collider2D> KnightManBossDetectedColiders = new List<Collider2D>();
    public Collider2D targetCollision;
    private void OnTriggerExit2D(Collider2D collision)
    {
        KnightManBossDetectedColiders.Remove(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KnightManBossDetectedColiders.Add(collision);
            targetCollision = collision;

        }
    }
}
