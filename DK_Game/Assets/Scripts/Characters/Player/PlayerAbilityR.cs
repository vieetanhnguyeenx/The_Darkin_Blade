using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityR : MonoBehaviour
{

    [SerializeField] public float BaseCooldown = 20f;
    [SerializeField] private float baseCooldownTimmer = 20f;

    [SerializeField] public float Duration = 15f;
    [SerializeField] public float DurationTimmer = 0f;

    [SerializeField] private bool isActivated = false;

    private StatModifier percentDamageAdd;
    private StatModifier flatDamage;
    private StatModifier flatLifeSteal;
    private Animator animator;
    private PlayerStats playerStats;

    public bool IsRCooldown
    {
        get
        {
            return baseCooldownTimmer > BaseCooldown;
        }
    }

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
                animator.SetTrigger(AnimationStrings.abilityR);
                ActiveR();
            }
            else
            {
                InActiveR();
            }
            isActivated = value;

            // To do UI
        }
    }

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        percentDamageAdd = new StatModifier(0.3f, StatModType.PercentAdd);
        flatDamage = new StatModifier(50, StatModType.Flat);
        flatLifeSteal = new StatModifier(0.3f, StatModType.Flat);
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DurationTimmer > Duration && IsActivated)
        {
            IsActivated = false;
        }
        if (!IsActivated)
        {
            baseCooldownTimmer += Time.deltaTime;
        }
        else
        {
            DurationTimmer += Time.deltaTime;
        }

    }

    public void OnActionR(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!IsCoolDown())
            {
                Debug.Log("Skill is on cooldown!!!");
                return;
            }
            if (IsActivated)
            {
                Debug.Log("Skill is on duration!!!");
                return;
            }

            if (!IsActivated)
            {
                IsActivated = true;
                baseCooldownTimmer = 0f;
            }
        }


    }

    private bool IsCoolDown()
    {
        return baseCooldownTimmer > BaseCooldown;
    }

    public void ActiveR()
    {
        playerStats.Damage.AddModifier(percentDamageAdd);
        playerStats.Damage.AddModifier(flatDamage);
        playerStats.LifeSteal.AddModifier(flatLifeSteal);
    }

    public void InActiveR()
    {
        playerStats.Damage.RemoveModifier(percentDamageAdd);
        playerStats.Damage.RemoveModifier(flatDamage);
        playerStats.LifeSteal.AddModifier(flatLifeSteal);
    }
}
