using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = .5f;
    private bool hasCorpse;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ouchhhh");   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Corpse" && !hasCorpse) {
            Debug.Log("Collected corpse!!!!");
            hasCorpse = true;
            Destroy(other.GameObject(), destroyDelay);
        }
        
        if (other.tag == "Corpse Dump" && hasCorpse) {
            Debug.Log("Corpse delivered!!!!");
            hasCorpse = false;
        }
    }
}
