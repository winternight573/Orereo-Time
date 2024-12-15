using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed;
    public bool left;

    void Update()
    {
        if (left)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > 21f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -21f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetDirection(bool isLeft)
    {
        left = isLeft;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerState>().Hit();

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
}
