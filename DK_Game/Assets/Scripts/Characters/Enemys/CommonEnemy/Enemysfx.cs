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
        src.Play();
    }
    public void HurtSound()
    {
        src.clip = hurt;
        src.Play();
    }
}
