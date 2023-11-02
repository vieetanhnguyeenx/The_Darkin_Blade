using UnityEngine;
using UnityEngine.UI;

public class PlayerFloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        healthBar.fillAmount = currentValue / maxValue;
    }
}
