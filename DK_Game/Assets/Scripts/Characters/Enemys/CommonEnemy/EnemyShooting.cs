using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    void Shoot()
    {
        gameObject.GetComponentInChildren<Enemysfx>().WeaponSound();
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
