using UnityEngine;

public class AudioLogic : MonoBehaviour
{
    public AudioClip[] platformBreakSounds;
    public AudioClip[] hitSounds;
    
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayPlatformBreakSound()
    {
        audioSource.clip = platformBreakSounds[0];
        audioSource.Play();
    }
    
    public void PlayHitSound()
    {
        audioSource.clip = hitSounds[0];
        audioSource.Play();
    }
}
