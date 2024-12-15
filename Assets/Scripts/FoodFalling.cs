using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFalling : MonoBehaviour
{
    public Transform lowerPlatform;
    private int collisionCount = 0;
    private bool collected = false;
    private Rigidbody rb;

    public void IncrementCollisionCount()
    {
        collisionCount++;
        if (collisionCount == 4)
        {
            collisionCount = 0;
            CapsuleBehavior[] capsules = GetComponentsInChildren<CapsuleBehavior>();
            foreach (CapsuleBehavior capsule in capsules)
            {
                capsule.ReturnToOldState();
            }
            FallToLowerPlatform();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform_Tile"))
        {
            lowerPlatform = other.GetComponent<PlatformFields>().targetPlatform.transform;
        }
        else if (other.CompareTag("Food Tile") && !other.GetComponent<FoodFalling>().collected)  // only when you are falling onto a uncollected food
        {
            other.GetComponent<FoodFalling>().FallToLowerPlatform();
        }
    }

    private void FallToLowerPlatform()
    {
        float targetY = lowerPlatform.position.y + 1;
        if (lowerPlatform.CompareTag("Collector"))
        {
            Debug.Log("Collector");
            collected = true;
            targetY += lowerPlatform.GetComponent<CollectorFields>().collectedCount;
            lowerPlatform.GetComponent<CollectorFields>().IncreaseCollectedCount();
        }
        StartCoroutine(FallRoutine(targetY));
    }

    private IEnumerator FallRoutine(float targetY)
    {
        float duration = 1f; // Time to reach the lower platform
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = new Vector3(initialPosition.x, targetY, initialPosition.z);
        float elapsed = 0;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
