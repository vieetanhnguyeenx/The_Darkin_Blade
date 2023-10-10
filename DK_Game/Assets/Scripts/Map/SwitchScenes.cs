using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float delay;
    public string nameScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            ModeSelect();
        }
    }
    public void ModeSelect()
    {
        
        SceneManager.LoadScene(nameScene);
    }
   
}
