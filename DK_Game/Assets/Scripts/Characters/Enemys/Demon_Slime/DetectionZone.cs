using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedColiders = new List<Collider2D>();

    private void OnTriggerExit2D(Collider2D collision)
    {
        detectedColiders.Remove(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectedColiders.Add(collision);
        }
    }
}
