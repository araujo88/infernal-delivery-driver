using UnityEngine;

public class TruckSoundController : MonoBehaviour
{
    public AudioClip movingSound;  // Drag your moving sound clip here in the inspector
    public AudioClip idleSound;    // Drag your idle sound clip here in the inspector
    public AudioClip bumpSound;  // Drag your bump sound clip here in the inspector
    private AudioSource audioSource;

    private bool isMoving = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayIdleSound();
    }

    private void Update()
    {
        // Assuming horizontal and vertical inputs control the truck's movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Check if the truck is moving or idle
        if (moveHorizontal != 0f || moveVertical != 0f)
        {
            if (!isMoving)
            {
                isMoving = true;
                PlayMovingSound();
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                PlayIdleSound();
            }
        }
    }

    void PlayMovingSound()
    {
        if (audioSource && movingSound)
        {
            audioSource.clip = movingSound;
            audioSource.loop = true;  // Loop the moving sound
            audioSource.Play();
        }
    }

    void PlayIdleSound()
    {
        if (audioSource && idleSound)
        {
            audioSource.clip = idleSound;
            audioSource.loop = true;  // Loop the idle sound
            audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a specific tag or name
        // For example, let's say the specific object has a tag "SpecialObject"
        if (collision.gameObject.CompareTag("Tree"))
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
