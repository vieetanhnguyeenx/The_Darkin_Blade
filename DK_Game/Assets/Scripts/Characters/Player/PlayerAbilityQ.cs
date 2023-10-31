using Assets.Scripts;
using Assets.Scripts.Characters;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityQ : MonoBehaviour
{
    [SerializeField] public Cooldown BaseCooldown;
    [SerializeField] public Cooldown GapBettwen;
    [SerializeField] public Cooldown ExistTime;

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
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnActionQ(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // If Q is cooldown when

        }
    }
}
