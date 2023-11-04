using System.Collections;
using UnityEngine;

public class Enemysfx : MonoBehaviour
{
    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip weapon, hurt, dead;

    public void WeaponSound()
    {
        src.enabled = true;
        src.PlayOneShot(weapon);
    }

    public void HurtSound()
    {
        src.enabled = true;
        src.PlayOneShot(hurt);
    }

    public void PlayDeadSound()
    {
        src.enabled = true;
        src.PlayOneShot(dead);
        StartCoroutine(DisableAudioSource());
    }

    IEnumerator DisableAudioSource()
    {
        yield return new WaitForSeconds(3.0f);
        src.enabled = false;
    }
}
