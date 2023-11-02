using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneFox : MonoBehaviour
{
    public List<Collider2D> FoxDetectedColiders = new List<Collider2D>();
    public Collider2D targetCollision;
    private void OnTriggerExit2D(Collider2D collision)
    {
        FoxDetectedColiders.Remove(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FoxDetectedColiders.Add(collision);
            targetCollision = collision;

        }
    }
}
