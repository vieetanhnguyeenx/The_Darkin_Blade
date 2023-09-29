using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rg;
    public float speed = 10.0F;
    public float jumpspeed = 10.0F;
    public Vector2 atas = new Vector2(0, 0.02f);
    public bool isGrounded = false;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Ground" || (col.gameObject.tag == "Stair") && isGrounded == false))
        {
            isGrounded = true;
        }
    }

    void Update()
    {
        float straffe = Input.GetAxis("Horizontal") * speed;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, 0);

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rg.AddForce(atas * speed, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;


    }
}
