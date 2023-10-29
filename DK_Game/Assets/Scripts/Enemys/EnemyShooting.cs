using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
