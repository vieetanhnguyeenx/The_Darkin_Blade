using UnityEngine;

public class ChangeOY : MonoBehaviour
{
    public float moveSpeed  ; 
    public float top  ;       
    public float bottom ;   

    private bool movingUp = true;

    void Update()
    {
        
        if (movingUp)
        {
            
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            
            if (transform.position.y >= top)
            {
                movingUp = false;
            }
        }
        else
        {
            
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            
            if (transform.position.y <= bottom)
            {
                movingUp = true;
            }
        }
    }
}
