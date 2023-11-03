using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityQ : MonoBehaviour
{
    public int skillActivationCount = 0;
    public int skillActivationMax = 3;

    public float baseCoolDown = 14.0f;
    public float baseCoolDownTimmer = 14.0f;

    public float timeSinceLastUseMax = 1f;
    public float timeSinceLastUse = 1.2f;

    public float timeSinceLastActivationMax = 6f;
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

    public bool IsQCooldown
    {
        get
        {
            return skillActivationCount >= skillActivationMax || baseCoolDownTimmer > baseCoolDown;
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
        baseCoolDownTimmer = 15f;
    }

    public void OnActionQ(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!IsCoolDown())
            {

                return;
            }

            if (timeSinceLastUse > timeSinceLastUseMax)
            {
                if (skillActivationCount < skillActivationMax)
                {

                    skillActive = true;
                    skillActivationCount++;
                    animator.SetTrigger(AnimationStrings.abilityQ1 + skillActivationCount);
                    Debug.Log("Q" + skillActivationCount);
                    timeSinceLastUse = 0f;
                    timeSinceLastActivation = 0f;
                    if (skillActivationCount == 3)
                    {
                        timeSinceLastActivation = 5f;
                    }
                }
                else
                {
                    baseCoolDownTimmer = 0;
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
        if (timeSinceLastActivation > timeSinceLastActivationMax)
        {
            timeSinceLastActivation = 0f;
            SkillActive = false;
            skillActivationCount = 0;
            timeSinceLastUse = 1.2f;
            Debug.Log("Skill goes on cooldown");
            baseCoolDownTimmer = 0;
            return;
        }


        if (!skillActive)
        {
            baseCoolDownTimmer += Time.deltaTime;
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
