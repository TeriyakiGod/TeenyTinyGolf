using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip puttSound;
    public AudioSource audioSource;
    
    public void PlayPuttSound()
    {
        audioSource.PlayOneShot(puttSound);
    }
}
