using UnityEngine;

public class EnemyFloatingTextHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.8f);
        float randomx = Random.Range(0f, 1f);
        float randomy = Random.Range(2f, 3f);
        transform.localPosition += new Vector3(randomx, randomy, 0);
    }
}
