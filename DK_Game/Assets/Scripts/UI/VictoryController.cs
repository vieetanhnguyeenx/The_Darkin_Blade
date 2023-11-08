using UnityEngine;

public class VictoryController : MonoBehaviour
{
    [SerializeField]
    private AudioSource src;
    [SerializeField]
    private AudioClip sound;

    public void VictorySound()
    {
        src.enabled = true;
        src.PlayOneShot(sound);
    }
}
