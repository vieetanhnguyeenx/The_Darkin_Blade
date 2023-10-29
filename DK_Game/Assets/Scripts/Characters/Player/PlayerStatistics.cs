using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
