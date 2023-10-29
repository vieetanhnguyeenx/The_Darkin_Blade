using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 10;

    private List<GameObject> bulletPool;

    private static BulletPool _instance;

    public static BulletPool Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        if (bullet != null)
        {
            bullet.SetActive(false);
        }
    }
}
