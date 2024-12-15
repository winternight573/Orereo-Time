using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public Transform[] spawnPoints;
    public float enemySpeed = 5f;
    private bool canSpawn = true;

    void Start()
    {
        int spawnPointsCount = transform.childCount;
        spawnPoints = new Transform[spawnPointsCount];
        for (int i = 0; i < spawnPointsCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (canSpawn)
            {
                // Select a random spawn point
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];

                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

                // Set the enemy's speed and direction
                EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
                if (enemyMovement != null)
                {
                    enemyMovement.SetSpeed(enemySpeed);
                    if (spawnPoint.position.x < -21f)
                    {
                        enemyMovement.SetDirection(true);
                    }
                }
            }
        }
    }

    public void SetCanSpawn(bool value)
    {
        Debug.Log("SetCanSpawn");
        canSpawn = value;
        if (value)
        {
            Debug.Log("I can Spawn");
        }
        else
        {
            Debug.Log("I cannot Spawn");
        }
    }
}
