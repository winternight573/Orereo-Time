using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerState : MonoBehaviour
{
    private int lives;
    private bool alive;
    private Vector3 startingPosition = new Vector3(0f, 13.825f, -0.94f);

    void Start()
    {
        lives = 3;
        alive = true;
    }
    public void Hit()
    {
        // Debug.Log("I am hit");
        GetComponents<AudioSource>()[0].Play();
        transform.gameObject.GetComponent<PlayerMovement>().SetCanMove(false);
        transform.position = startingPosition;
        lives--;
        if (lives == 0)
        {
            GetComponents<AudioSource>()[1].Play();
            alive = false;
        } else
        {
            transform.gameObject.GetComponent<PlayerMovement>().SetCanMove(true);
        }
    }

    public bool IsAlive()
    {
        return alive;
    }
}
