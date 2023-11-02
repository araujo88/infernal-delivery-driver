using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip bumpSound;  // Drag your bump sound clip here in the inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has a specific tag or name
        // For example, let's say the specific object has a tag "SpecialObject"
        if (other.gameObject.CompareTag("Player"))
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        if (audioSource && bumpSound)
        {
            audioSource.clip = bumpSound;
            audioSource.Play();
        }
    }
}
