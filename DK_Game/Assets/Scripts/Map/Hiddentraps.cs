using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiddentraps : MonoBehaviour
{
    public float timedelay;
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
            StartCoroutine(DelayedActionFunction(timedelay));
            
        }
    }
    private IEnumerator DelayedActionFunction(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        gameObject.SetActive(false);
    }

}
