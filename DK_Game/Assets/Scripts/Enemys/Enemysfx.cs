using UnityEngine;

public class Enemysfx : MonoBehaviour
{
    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip arrow, hurt;

    public void ArrowSound()
    {
        src.clip = arrow;
        src.Play();
    }
    public void HurtSound()
    {
        //src.clip = hurt;
        //src.Play();
    }
}
