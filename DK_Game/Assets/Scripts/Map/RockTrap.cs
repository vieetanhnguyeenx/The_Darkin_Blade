using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aa");
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(true);

        }
    }
}
