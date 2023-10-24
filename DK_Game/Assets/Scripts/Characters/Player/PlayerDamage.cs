using Assets.Scripts;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    PlayerStats playerStats;
    Animator animator;



    private float _currentHealth;

    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            // if  heath drop below 0, character is no longer alive
            if (_currentHealth < 0)
            {
                IsAlive = false;
            }
        }
    }

    private bool _isAlive;
    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
        }
    }

    private void Awake()
    {
        _currentHealth = playerStats.MaxHealth.Value;
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
