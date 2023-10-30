using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScence : MonoBehaviour
{
    public string nameScence;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("nhu lol");
            collision.gameObject.SetActive(false);  
            SceneManager.LoadScene(nameScence);
        }
    }

}
