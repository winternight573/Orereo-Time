using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionStatus : MonoBehaviour
{
    private int collectionCompleteCount = 0;
    private bool collectionCompleted = false;
    public void IncrementProgress()
    {
        collectionCompleteCount++;
        GetComponents<AudioSource>()[0].Play();
        // Debug.Log(collectionCompleteCount);
        if (collectionCompleteCount == 4)
        {
            GetComponents<AudioSource>()[1].Play();
            collectionCompleted = true;
        }
    }

    public bool CollectionCompletion()
    {
        return collectionCompleted;
    }
}
