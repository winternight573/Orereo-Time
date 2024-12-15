using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private bool isOnLadder;
    private bool isOnPlatform;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        
        canMove = true;
        isOnLadder = false;
        isOnPlatform = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector3 movement;
            if (isOnLadder && isOnPlatform)
            {
                float moveX = Input.GetAxis("Horizontal");
                float moveY = Input.GetAxis("Vertical");

                movement = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
            }
            else if (isOnPlatform)
            {
                // only horizontal movement
                float moveX = Input.GetAxisRaw("Horizontal");
                movement = new Vector3(moveX, 0, 0) * speed * Time.deltaTime;
            }
            else  // isOnLadder
            {
                // only vertical movement
                float moveY = Input.GetAxisRaw("Vertical");
                movement = new Vector3(0, moveY, 0) * speed * Time.deltaTime;
            }
            rb.MovePosition(rb.position + movement);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = true;
            // Debug.Log("Enter Ladder");
        } 
        else if (other.CompareTag("Platform"))
        {
            isOnPlatform = true;
            // Debug.Log("Enter Platform");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = false;
            // Debug.Log("Exit Ladder");
        }
        else if (other.CompareTag("Platform"))
        {
            isOnPlatform = false;
            // Debug.Log("Exit Platform");
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
        if (value)
        {
            Debug.Log("I can move");
        }
        else
        {
            Debug.Log("I cannot move");
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collided with: " + collision.gameObject.name);
    //}
}
