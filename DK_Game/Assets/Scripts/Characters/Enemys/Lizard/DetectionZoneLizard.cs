using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneLizard : MonoBehaviour
{
    public List<Collider2D> LizardDetectedColiders = new List<Collider2D>();
    public Collider2D targetCollision;
    private void OnTriggerExit2D(Collider2D collision)
    {
        LizardDetectedColiders.Remove(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LizardDetectedColiders.Add(collision);
            targetCollision = collision;

        }
    }
}
