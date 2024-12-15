using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // References to UI Canvases
    public GameObject startOverlay;
    public GameObject endLostOverlay;
    public GameObject endWonOverlay;

    IEnumerator Start()
    {
        yield return null;

        // Initially show the start overlay
        startOverlay.SetActive(true);
        endLostOverlay.SetActive(false);
        endWonOverlay.SetActive(false);

        GameMovement(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter key
        {
            StartGame();
        }
        else
        {
            CheckEndGame();
        }
    }

    void StartGame()
    {
        startOverlay.SetActive(false);
        GameMovement(true);
    }

    public void EndGame(bool hasWon)
    {
        GameMovement(false);

        if (hasWon)
        {
            endWonOverlay.SetActive(true);
        } 
        else
        {
            endLostOverlay.SetActive(true);
        }
    }

    private void GameMovement(bool moving)
    {
        GameObject enemySpawnPoints = GameObject.FindGameObjectWithTag("Enemy_Spawn_Point");
        enemySpawnPoints.GetComponent<EnemySpawner>().SetCanSpawn(moving);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMovement>().SetCanMove(moving);
    }

    private void CheckEndGame()
    {
        GameObject player = GameObject.FindWithTag("Player");
        bool alive = player.GetComponent<PlayerState>().IsAlive();
        GameObject collector = GameObject.FindWithTag("Collector");
        bool hasCompleted = collector.GetComponentInParent<CollectionStatus>().CollectionCompletion();

        if (!alive)
        {
            EndGame(false);
        }
        else if (hasCompleted)
        {
            EndGame(true);
        }
    }
}
