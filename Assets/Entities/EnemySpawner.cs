using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemy = 5;

    public Enemy enemy;

    public float spawnInterval = 500;
    private float nextSpawnTime;

    private GameObject player;

    private void Start() 
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        SpawnEnemy(GetNumberOfEnemy());
    }

    private int GetNumberOfEnemy()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void SpawnEnemy(int actualNumberOfEnemy)
    {
        if (actualNumberOfEnemy <= maxEnemy)
        {
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime = Time.time + spawnInterval;

                Enemy newEnemy = Instantiate(enemy, this.transform.position, this.transform.rotation) as Enemy;
                newEnemy.player = player;
            }
        }
    }
}
