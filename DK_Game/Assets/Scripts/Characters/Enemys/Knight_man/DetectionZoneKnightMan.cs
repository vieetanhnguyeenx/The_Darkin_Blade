using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneKnightMan : MonoBehaviour
{
    public List<Collider2D> KnightManDetectedColiders = new List<Collider2D>();
    public Collider2D targetCollision;
    private void OnTriggerExit2D(Collider2D collision)
    {
        KnightManDetectedColiders.Remove(collision);
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
