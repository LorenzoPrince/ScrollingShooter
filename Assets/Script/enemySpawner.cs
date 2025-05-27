using System.Collections;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [Header("Velocidad base de los enemigos")]
    public float baseSpeed = 8f;
    public float speedIncreasePerWave = 5f;

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

    [Header("Profundidad de aparición (Z)")]
    public float spawnZ = 128f; // Aparecerán lejos del jugador/cámara

    [Header("Control de oleadas")]
    public float spawnInterval = 5f;
    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 5f;

    private int currentWave = 0;

    void Start()
    {
        Debug.Log("Inicia Start de enemySpawner");
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
                Debug.Log("primera oleada");
            }

            if (currentWave >= 5)
            {
                SpawnBoss();
                Debug.Log("SPAWNEA EL BOSS");
                yield break; // terminamos tras el boss
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        int enemyType = Random.Range(1, currentWave + 1);

        Vector3 spawnPos = Vector3.zero;
        GameObject enemy = null; //esto va a servir para cambiar dps

        if (enemyType == 2)
        {
            float x = Random.Range(minX, maxX);
            float y = maxY;
            spawnPos = new Vector3(x, y, spawnZ);
            enemy = Instantiate(enemyType2, spawnPos, Quaternion.identity);
        }
        else
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            spawnPos = new Vector3(x, y, spawnZ);

            if (enemyType == 1)
                enemy = Instantiate(enemyType1, spawnPos, Quaternion.identity);
            else
                enemy = Instantiate(enemyType3, spawnPos, Quaternion.identity);
        }
        // Ajustamos la velocidad del enemigo según la oleada
        if (enemy != null)
        {
            enemyMove movement = enemy.GetComponent<enemyMove>();
            if (movement != null)
            {
                float speed = baseSpeed + (currentWave - 1) * speedIncreasePerWave;
                movement.SetSpeed(speed);
            }
            else
            {
                Debug.LogWarning("El prefab enemigo no tiene componente enemyMove!");
            }
        }
    }

    void SpawnBoss()
    {
        Vector3 bossSpawnPos = new Vector3(0, maxY, spawnZ);
        Instantiate(bossEnemy, bossSpawnPos, Quaternion.identity);
        Debug.Log("¡Boss ha aparecido!");
    }
}
