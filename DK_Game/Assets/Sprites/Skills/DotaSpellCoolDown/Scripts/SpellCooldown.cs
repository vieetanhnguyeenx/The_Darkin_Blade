﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellCooldown : MonoBehaviour
{
    [Header("UI items for Spell Cooldown")]
    [Tooltip("Tooltip example")]
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;
    [SerializeField]
    private Image imageEdge;
    [SerializeField]
    private KeyCode Key;
    [SerializeField]
    private float cooldownTime;

    //variable for looking after the cooldown
    private bool isCoolDown = false;
    private float cooldownTimer = 0.0f;
    private GameObject player;
    private PlayerAbilityQ playerAbilityQ;
    private PlayerAbilityW playerAbilityW;
    private PlayerAbilityE playerAbilityE;
    private PlayerAbilityR playerAbilityR;
    [SerializeField]
    private GameObject R, W;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAbilityQ = player.GetComponent<PlayerAbilityQ>();
        playerAbilityW = player.GetComponent<PlayerAbilityW>();
        playerAbilityE = player.GetComponent<PlayerAbilityE>();
        playerAbilityR = player.GetComponent<PlayerAbilityR>();
        textCooldown.gameObject.SetActive(false);
        imageEdge.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Key)
        {
            case KeyCode.P:
                break;
            case KeyCode.Q:
                if (playerAbilityQ.IsQCooldown)
                {
                    return;
                }

                bool spellUsedQ = UseSpell();

                if (spellUsedQ)
                {
                    cooldownTimer = playerAbilityQ.baseCoolDown;
                }

                if (!playerAbilityQ.IsQCooldown)
                {
                    ApplyCooldown();
                }
                break;
            case KeyCode.W:
                if (playerAbilityW.IsActivated)
                    W.SetActive(true);
                else
                    W.SetActive(false);
                break;
            case KeyCode.E:
                if (playerAbilityE.IsECooldown)
                {
                    return;
                }

                bool spellUsedE = UseSpell();

                if (spellUsedE)
                {
                    cooldownTimer = playerAbilityE.BaseCooldown;
                }

                if (!playerAbilityE.IsECooldown)
                {
                    ApplyCooldown();
                }
                break;
            case KeyCode.R:
                if (playerAbilityR.IsActivated)
                    R.SetActive(true);
                else
                    R.SetActive(false);
                if (playerAbilityR.IsRCooldown)
                {
                    return;
                }

                bool spellUsedR = UseSpell();

                if (spellUsedR)
                {
                    cooldownTimer = playerAbilityR.BaseCooldown;
                }

                if (!playerAbilityR.IsRCooldown)
                {
                    ApplyCooldown();
                }
                break;
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0.0f)
        {
            isCoolDown = false;
            textCooldown.gameObject.SetActive(false);
            imageEdge.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;

            imageEdge.transform.localEulerAngles = new Vector3(0, 0, 360.0f * (cooldownTimer / cooldownTime));
        }

    }

    public bool UseSpell()
    {
        if (isCoolDown)
        {
            return false;
        }
        else
        {
            isCoolDown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = 1.0f;

            imageEdge.gameObject.SetActive(true);
            return true;
        }
    }
}
