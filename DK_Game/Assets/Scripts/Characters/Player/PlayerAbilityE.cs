using Assets.Scripts.Characters;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAbilityE : MonoBehaviour
{
    [SerializeField] public UnityEvent<float> Dashing;
    public float BaseCooldown = 3f;
    public float BaseCooldownTimmer = 3f;
    [SerializeField] public float DashingPower = 5f;
    [SerializeField] public GameObject player;
    private PlayerController playerController;
    private PlayerDamage playerDamage;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerDamage = GetComponent<PlayerDamage>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Dashing.AddListener(playerDamage.GetComponent<IDashingable>().Dashing);
    }

    // Update is called once per frame
    void Update()
    {
        BaseCooldownTimmer += Time.deltaTime;
    }

    public void OnActionE(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (IsCooldown())
            {
                Dashing?.Invoke(DashingPower);
                BaseCooldownTimmer = 0f;
            }
        }

    }

    public bool IsCooldown()
    {
        return BaseCooldownTimmer > BaseCooldown;
    }
}
