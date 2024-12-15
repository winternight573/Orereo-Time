using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorFields : MonoBehaviour
{
    public int collectedCount = 0;

    public void IncreaseCollectedCount()
    {
        collectedCount++;
        // Debug.Log(collectedCount);

        if (collectedCount == 4)
        {
            // Debug.Log("Done!");
            GetComponentInParent<CollectionStatus>().IncrementProgress();
        }
    }
}
