using Assets.Scripts.Characters;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityW : MonoBehaviour
{
    [SerializeField] private bool isActivated = false;
    [SerializeField] public float punishPercentRate = 0.05f;
    private PlayerStats playerStats;
    private StatModifier percentDamageAdd;
    private StatModifier flatDamage;
    public bool IsActivated
    {
        get
        {
            return isActivated;
        }
        set
        {
            if (value)
            {
                ActiveW();
            }
            else
            {
                InActiveW();
            }
            isActivated = value;

            // To do UI
        }
    }

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        percentDamageAdd = new StatModifier(0.2f, StatModType.PercentAdd);
        flatDamage = new StatModifier(30, StatModType.Flat);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnActionW(InputAction.CallbackContext context)
    {
        if (context.performed)
            IsActivated = !IsActivated;
    }

    public void ActiveW()
    {
        playerStats.Damage.AddModifier(percentDamageAdd);
        playerStats.Damage.AddModifier(flatDamage);
    }

    public void InActiveW()
    {
        playerStats.Damage.RemoveModifier(percentDamageAdd);
        playerStats.Damage.RemoveModifier(flatDamage);
    }
}
