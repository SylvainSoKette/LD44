using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemy = 5;
    public Enemy enemy;

    public float spawnDistance = 1f;
    public float spawnInterval = 1f;
    float nextSpawnTime;

    GameObject player;

    private void Start() 
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        SpawnEnemies();
    }

    private int GetNumberOfEnemy()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void SpawnEnemies()
    {
        if (GetNumberOfEnemy() <= maxEnemy)
        {
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime = Time.time + spawnInterval;

                Vector3 spawnDirection = new Vector3(
                    Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f),
                    0
                ).normalized;

                Vector3 spawnPosition = new Vector3(
                    this.player.transform.position.x + spawnDirection.x * this.spawnDistance,
                    this.player.transform.position.y + spawnDirection.y * this.spawnDistance,
                    0
                );

                Enemy newEnemy = Instantiate(
                    enemy,
                    spawnPosition,
                    Quaternion.identity
                ) as Enemy;
                newEnemy.Initiate();
            }
        }
    }
}
