using UnityEngine;

public class Enemysfx : MonoBehaviour
{
    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip weapon, hurt;

    public void WeaponSound()
    {
        src.clip = weapon;
        if (!src.DisableGamepadOutput())
            src.Play();
    }
    public void HurtSound()
    {
        src.clip = hurt;
        if (!src.DisableGamepadOutput())
            src.Play();
    }
}
