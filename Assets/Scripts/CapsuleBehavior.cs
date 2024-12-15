using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBehavior : MonoBehaviour
{
    public bool hasCollided = false;
    public float translateAmount = 1f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollided)
        {
            hasCollided = true;
            GetComponent<AudioSource>().Play();
            transform.Translate(Vector3.down * translateAmount);
            transform.parent.GetComponent<FoodFalling>().IncrementCollisionCount();
        }
    }

    public void ReturnToOldState()
    {
        hasCollided = false;
        transform.Translate(Vector3.up * translateAmount);
    }
}
