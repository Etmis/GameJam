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
        MakeWaves();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && currentWaveIndex < waves.Count)
        {
            StartWave(waves[currentWaveIndex]);
            currentWaveIndex++;
        }
    }

    public void StartWave(Wave wave)
    {
        StartCoroutine(SpawnEnemies(wave));
    }

    public IEnumerator SpawnEnemies(Wave wave)
    {
        yield return new WaitForSeconds(10);
        foreach (EnemySpawnData spawnData in wave.enemies)
        {
            for (int i = 0; i < spawnData.count; i++)
            {
                yield return new WaitForSeconds(spawnData.cooldown);
                Instantiate(spawnData.enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            }
        }
    }

    private void MakeWaves()
    {
        Wave firstWave = new Wave();
        firstWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 5, cooldown = 2f });
        waves.Add(firstWave);
        //----------------------------------
        Wave secondWave = new Wave();
        secondWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 5, cooldown = 2f });
        secondWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 3, cooldown = 1f });
        waves.Add(secondWave);
    }
}

public class Wave
{
    public List<EnemySpawnData> enemies = new List<EnemySpawnData>();
}

public class EnemySpawnData
{
    public GameObject enemyPrefab;
    public int count;
    public float cooldown;
}
