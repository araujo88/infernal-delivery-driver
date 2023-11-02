using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private int steerSpeed = 100;
    [SerializeField] private int moveSpeed = -10;
    [SerializeField] private int slowMoveSpeed = -5;
    [SerializeField] private int fastMoveSpeed = -15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical")*moveSpeed * Time.deltaTime;
        
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Tree") {
            Debug.Log("Bumped into a tree!!");
            moveSpeed = -slowMoveSpeed;
            DelayedAction(2);
            moveSpeed = -10;
        }
    }

   IEnumerator DelayedAction(int seconds)
    {
        yield return new WaitForSeconds(seconds); 
    }
}
