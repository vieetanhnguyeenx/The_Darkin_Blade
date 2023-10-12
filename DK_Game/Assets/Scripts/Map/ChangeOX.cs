using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOX : MonoBehaviour
{
    private bool checkleft;
    private bool checkright;
    public float pointleft;
    public float pointright;
    // Start is called before the first frame update
    void Start()
    {
        checkleft = true; checkright = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= pointright && checkright == true)
        {
            transform.position = new Vector3(transform.position.x + (1 * Time.deltaTime), transform.position.y , transform.position.z);

        }
        if (transform.position.x > pointright)
        {
            checkright = false;
            checkleft = true;
        }
        if (transform.position.x >= pointleft && checkleft == true)
        {
            transform.position = new Vector3(transform.position.x - (1 * Time.deltaTime), transform.position.y , transform.position.z);

        }
        if (transform.position.x < pointleft)
        {
            checkright = true;
            checkleft = false;
        }
    }
}
