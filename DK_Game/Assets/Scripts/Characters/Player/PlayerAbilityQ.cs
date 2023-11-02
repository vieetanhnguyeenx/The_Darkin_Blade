using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityQ : MonoBehaviour
{
    public int skillActivationCount = 0;
    public int skillActivationMax = 3;

    public float baseCoolDown = 14.0f;
    public float baseCoolDownTimmer = 0f;

    public float timeSinceLastUseMax = 1f;
    public float timeSinceLastUse = 1.2f;

    public float timeSinceLastActivationMax = 4f;
    public float timeSinceLastActivation = 0f;

    private Animator animator;
    private bool isAvalibale;

    [SerializeField]
    public bool IsAvalibale
    {
        get
        {
            return isAvalibale;
        }
        private set
        {
            animator.SetBool(AnimationStrings.isAbilityQAvalible, value);
            isAvalibale = value;
        }
    }

    private bool skillActive = false;

    public bool SkillActive
    {
        get
        {
            return skillActive;
        }
        set
        {
            skillActive = value;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnActionQ(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!IsCoolDown())
            {
                Debug.Log("Skill is on cooldown!!!");
                return;
            }
            if (timeSinceLastActivation > timeSinceLastActivationMax)
            {
                timeSinceLastActivation = 0f;
                SkillActive = false;
                skillActivationCount = 0;
                timeSinceLastUse = 1.2f;
                Debug.Log("Skill goes on cooldown");
                return;
            }
            if (timeSinceLastUse > timeSinceLastActivation)
            {
                if (skillActivationCount < skillActivationMax)
                {
                    skillActive = true;
                    skillActivationCount++;
                    //animator.SetTrigger(AnimationStrings.abilityQ1 + skillActivationCount);
                    Debug.Log("Q" + skillActivationCount);
                    timeSinceLastUse = 0f;
                }
                else
                {
                    timeSinceLastActivation = 0f;
                    SkillActive = false;
                    skillActivationCount = 0;
                    timeSinceLastUse = 1.2f;
                    Debug.Log("Skill goes on cooldown");
                }
            }
        }
    }
    private void Update()
    {

        if (!skillActive)
        {
            baseCoolDownTimmer += Time.deltaTime;
            timeSinceLastActivation = 0;
            timeSinceLastUse = 0;
        }
        else
        {
            timeSinceLastActivation += Time.deltaTime;
            timeSinceLastUse += Time.deltaTime;
        }
    }

    private bool IsCoolDown()
    {
        return baseCoolDownTimmer > baseCoolDown;
    }

}
