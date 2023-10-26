using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOX : MonoBehaviour
{
    public float moveSpeed ; 
    public float left ;     
    public float right ;     

    private bool movingRight = true;

    void Update()
    {
       
        if (movingRight)
        {
           
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            
            if (transform.position.x >= right)
            {
                movingRight = false;
            }
        }
        else
        {
           
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            
            if (transform.position.x <= left)
            {
                movingRight = true;
            }
        }
    }
}
