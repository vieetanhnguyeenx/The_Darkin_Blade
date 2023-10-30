using UnityEngine;
using UnityEngine.InputSystem;

public class BasicAttackManager : MonoBehaviour
{
    public static BasicAttackManager instance;


    public bool canReceiveInput;
    public bool inputRecived;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canReceiveInput)
            {
                inputRecived = true;
                canReceiveInput = false;
            }
            else
            {
                return;
            }
        }
    }

    public void InputManager()
    {
        if (!canReceiveInput)
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;
        }
    }
}
