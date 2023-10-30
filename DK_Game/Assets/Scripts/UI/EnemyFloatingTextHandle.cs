using UnityEngine;

public class EnemyFloatingTextHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.8f);
        transform.localPosition += new Vector3(0, 2f, 0);
    }
}
