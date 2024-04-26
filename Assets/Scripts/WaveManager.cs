using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject firstEnemy;
    [SerializeField] GameObject secondEnemy;
    [SerializeField] GameObject thirdEnemy;
    [SerializeField] GameObject fourthEnemy;
    [SerializeField] GameObject fifthEnemy;
    [SerializeField] GameObject sixthEnemy;
    [SerializeField] GameObject seventhEnemy;
    [SerializeField] GameObject eighthEnemy;
    [SerializeField] GameObject ninethEnemy;
    [SerializeField] GameObject tenthEnemy;

    List<Wave> waves = new List<Wave>();

    int currentWaveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Wave firstWave = new Wave();

        // Add enemy spawn data for the first wave
        firstWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 5, cooldown = 2f });
        firstWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 3, cooldown = 1f });

        waves.Add(firstWave);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && currentWaveIndex < waves.Count)
        {
            StartWave(waves[currentWaveIndex]);
            currentWaveIndex++; // Move to the next wave after starting current one
        }
    }

    public void StartWave(Wave wave)
    {
        StartCoroutine(SpawnEnemies(wave));
    }

    public IEnumerator SpawnEnemies(Wave wave)
    {
        foreach (EnemySpawnData spawnData in wave.enemies)
        {
            for (int i = 0; i < spawnData.count; i++)
            {
                yield return new WaitForSeconds(spawnData.cooldown);
                Instantiate(spawnData.enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
}

public class Wave // Defines a single wave configuration
{
    public List<EnemySpawnData> enemies = new List<EnemySpawnData>();
}

public class EnemySpawnData // Defines data for spawning a specific enemy type
{
    public GameObject enemyPrefab;
    public int count;
    public float cooldown;
}
