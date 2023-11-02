using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    [SerializeField] public float speed = 2.0f; // Movement speed of the object
    [SerializeField] public float detectionDistance = 10.0f;
    [SerializeField] public float stopDistance = 2.0f;
    
    private bool inContact = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public AudioClip zombieSound;
    private AudioSource audioSource;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = (player.position - transform.position).magnitude;

        // If the player is within the detection distance
        if (distanceToPlayer <= detectionDistance)
        {
            // Calculate the direction to move towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Flip sprite based on direction
            if (direction.x > 0.01f)  // Moving right
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (direction.x < -0.01f)  // Moving left
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            // Move the object towards the player
            transform.position += direction * speed * Time.deltaTime;

            // Stop at a certain distance
            if(distanceToPlayer > stopDistance)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object it collided with is the player
        if (collision.gameObject.transform == player)
        {
            // Set the animator's parameter to trigger the contact animation
            animator.SetBool("inContact", true);
            PlaySound();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.transform == player)
        {
            // Reset the animator's parameter to return to the original animation
            animator.SetBool("inContact", false);
            audioSource.Stop();
        }
    }

    void PlaySound()
    {
        if (audioSource && zombieSound)
        {
            audioSource.clip = zombieSound;
            audioSource.Play();
        }
    }
}
