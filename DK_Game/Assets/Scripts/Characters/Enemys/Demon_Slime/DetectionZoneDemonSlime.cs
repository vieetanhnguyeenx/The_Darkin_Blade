using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneDemonSlime : MonoBehaviour
{
    public List<Collider2D> DemonSlimeDetectedColiders = new List<Collider2D>();

    private void OnTriggerExit2D(Collider2D collision)
    {
        DemonSlimeDetectedColiders.Remove(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DemonSlimeDetectedColiders.Add(collision);
        }
    }
}
