using UnityEngine;

public class ChangeOY : MonoBehaviour
{
    private bool checkup;
    private bool checkdown;
    public float pointhigh;
    public float pointbottom;
    // Start is called before the first frame update
    void Start()
    {
        checkup = true; checkdown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= pointhigh && checkup == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (2 * Time.deltaTime), transform.position.z);

        }
        if (transform.position.y > pointhigh)
        {
            checkup = false;
            checkdown = true;
        }
        if (transform.position.y >= pointbottom && checkdown == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (2 * Time.deltaTime), transform.position.z);

        }
        if (transform.position.y < pointbottom)
        {
            checkup = true;
            checkdown = false;
        }
    }
}
