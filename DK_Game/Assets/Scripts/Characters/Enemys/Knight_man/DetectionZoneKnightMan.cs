using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneKnightMan : MonoBehaviour
{
    public List<Collider2D> KnightManDetectedColiders = new List<Collider2D>();
    KnightManStats knightManStats;
    public Collider2D targetCollision;
    private void Awake()
    {
        knightManStats = GetComponent<KnightManStats>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        KnightManDetectedColiders.Remove(collision);
        targetCollision = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KnightManDetectedColiders.Add(collision);
            targetCollision = collision;

        }
    }
}
