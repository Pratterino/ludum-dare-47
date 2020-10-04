using UnityEngine;

public class AudioLogic : MonoBehaviour
{

    public AudioClip deadSound;
    public AudioClip coinSound;
    public AudioClip music;
    
    public AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayDeadSound()
    {
        audioSource.clip = deadSound;
        audioSource.Play();
    }    
    
    public void PlayMusic()
    {
        audioSource.clip = music;
        audioSource.Play();
    }
    
    public void PlayCoinSound()
    {
        audioSource.clip = coinSound;
        audioSource.Play();
    }
}
