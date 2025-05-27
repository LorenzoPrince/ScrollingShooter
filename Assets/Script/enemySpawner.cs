using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [Header("Prefabs de enemigos")]
    public GameObject enemyType1;
    public GameObject enemyType2; // Bombardero
    public GameObject enemyType3;
    public GameObject bossEnemy;

    [Header("Rango de aparición (limites)")]
    public float minX = -4.69f;
    public float maxX = 4.69f;
    public float minY = -2.02f;
    public float maxY = 3.02f;

    [Header("Control de oleadas")]
    public float spawnInterval = 8f;
    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 20f;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++;
            Debug.Log("Oleada " + currentWave);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }

            if (currentWave >= 4)
            {
                SpawnBoss();
                yield break; // terminamos tras el boss
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        int enemyType = Random.Range(1, currentWave + 1);

        Vector3 spawnPos = Vector3.zero;

        if (enemyType == 2)
        {
            float x = Random.Range(minX, maxX);
            float y = maxY;
            spawnPos = new Vector3(x, y, 0);
            Instantiate(enemyType2, spawnPos, Quaternion.identity);
        }
        else
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            spawnPos = new Vector3(x, y, 0);

            if (enemyType == 1)
                Instantiate(enemyType1, spawnPos, Quaternion.identity);
            else
                Instantiate(enemyType3, spawnPos, Quaternion.identity);
        }
    }

    void SpawnBoss()
    {
        Vector3 bossSpawnPos = new Vector3(0, maxY, 0);
        Instantiate(bossEnemy, bossSpawnPos, Quaternion.identity);
        Debug.Log("¡Boss ha aparecido!");
    }
}
