using System.Collections;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject escortEnemy;

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

    [Header("Z más cerca para el jefe y escoltas")]
    public float bossSpawnZ = 60f; // 

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
            // Escalado de dificultad
            float speed = baseSpeed + (currentWave - 1) * speedIncreasePerWave;
            float newBulletForce = 10f; // Siempre igual
            //float newBulletForce = 10f + (currentWave - 1) * 2f;
            float newFireRate = Mathf.Max(0.75f, 2f - (currentWave - 1) * 0.2f);

            // Velocidad de movimiento
            enemyMove movement = enemy.GetComponent<enemyMove>();
            if (movement != null)
            {
                movement.SetSpeed(speed);
            }

            // Velocidad y frecuencia de disparo
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.SetBulletForce(newBulletForce);
                enemyScript.SetFireRate(newFireRate);
            }
            else
            {
                EnemyWeapon weaponScript = enemy.GetComponent<EnemyWeapon>();
                if (weaponScript != null)
                {
                    weaponScript.SetBulletForce(newBulletForce);
                    weaponScript.SetFireRate(newFireRate);
                }
                else
                {
                    Debug.LogWarning("El enemigo no tiene ni Enemy ni EnemyWeapon.");
                }
            }
        }
    }

    void SpawnBoss()
    {
        Vector3 bossSpawnPos = new Vector3(0, maxY, bossSpawnZ);
        GameObject boss = Instantiate(bossEnemy, bossSpawnPos, Quaternion.identity);

        // Aumentar la vida del jefe (accediendo al componente EnemyWeapon)
        EnemyWeapon weapon = boss.GetComponent<EnemyWeapon>();
        if (weapon != null)
        {
            weapon.SetMaxHealth(300); // Por ejemplo, 300 de vida
        }

        // Spawnear escoltas
        float escortOffsetX = 2f; // distancia lateral
        Vector3 leftEscortPos = bossSpawnPos + new Vector3(-escortOffsetX, 0, 0);
        Vector3 rightEscortPos = bossSpawnPos + new Vector3(escortOffsetX, 0, 0);

        Instantiate(escortEnemy, leftEscortPos, Quaternion.identity);
        Instantiate(escortEnemy, rightEscortPos, Quaternion.identity);

        Debug.Log("¡Boss ha aparecido con escoltas!");

    }
}
