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
    [SerializeField] GameObject eleventhEnemy;

    public List<Wave> waves = new List<Wave>();

    int currentWaveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        MakeWaves();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartWave()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        foreach (Wave wave in waves)
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
    }

    private void MakeWaves()
    {
        Wave firstWave = new Wave();
        firstWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 3, cooldown = 2f });
        waves.Add(firstWave);
        //----------------------------------//
        Wave secondWave = new Wave();
        secondWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 5, cooldown = 2f });
        waves.Add(secondWave);
        //----------------------------------//
        Wave thirdWave = new Wave();
        thirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 5, cooldown = 2f });
        thirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 3, cooldown = 2f });
        //----------------------------------//
        Wave fourthWave = new Wave();
        fourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 4, cooldown = 2.5f });
        fourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 6, cooldown = 2.5f });
        waves.Add(fourthWave);
        //----------------------------------//
        Wave fifthWave = new Wave();
        fifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 7, cooldown = 2f });
        fifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 4, cooldown = 2.5f });
        fifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 3, cooldown = 2.5f });
        waves.Add(fifthWave);
        //----------------------------------//
        Wave sixthWave = new Wave();
        sixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 5, cooldown = 3f });
        sixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 4, cooldown = 3f });
        waves.Add(sixthWave);
        //----------------------------------//
        Wave seventhWave = new Wave();
        seventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 7, cooldown = 2f });
        seventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 6, cooldown = 3.5f });
        seventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 4, cooldown = 3.5f });
        waves.Add(seventhWave);
        //----------------------------------//
        Wave eighthWave = new Wave();
        eighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 8, cooldown = 3.5f });
        eighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 2, cooldown = 3.5f });
        waves.Add(eighthWave);
        //----------------------------------//
        Wave ninthWave = new Wave();
        ninthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 7, cooldown = 4f });
        ninthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 3, cooldown = 4f });
        waves.Add(ninthWave);
        //----------------------------------//
        Wave tenthWave = new Wave();
        tenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 5, cooldown = 4.5f });
        tenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 5, cooldown = 4.5f });
        waves.Add(tenthWave);
        //----------------------------------//
        Wave eleventhWave = new Wave();
        eleventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 10, cooldown = 2f });
        eleventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 8, cooldown = 4.5f });
        eleventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 2, cooldown = 4.5f });
        waves.Add(eleventhWave);
        Wave twelfthWave = new Wave();
        twelfthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 10, cooldown = 2.5f });
        twelfthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 4, cooldown = 3f });
        waves.Add(twelfthWave);

        Wave thirteenthWave = new Wave();
        thirteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 9, cooldown = 2.5f });
        thirteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 6, cooldown = 3f });
        waves.Add(thirteenthWave);

        Wave fourteenthWave = new Wave();
        fourteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 8, cooldown = 3f });
        fourteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 8, cooldown = 3f });
        waves.Add(fourteenthWave);

        Wave fifteenthWave = new Wave();
        fifteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 3, cooldown = 2f });
        fifteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 12, cooldown = 2.5f });
        fifteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 5, cooldown = 3f });
        waves.Add(fifteenthWave);

        Wave sixteenthWave = new Wave();
        sixteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 10, cooldown = 2f });
        sixteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 10, cooldown = 3f });
        sixteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 8, cooldown = 3f });
        waves.Add(sixteenthWave);

        Wave seventeenthWave = new Wave();
        seventeenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 8, cooldown = 3f });
        seventeenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 10, cooldown = 3f });
        seventeenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 5, cooldown = 3f });
        waves.Add(seventeenthWave);

        Wave eighteenthWave = new Wave();
        eighteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 5, cooldown = 2f });
        eighteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 14, cooldown = 2.5f });
        eighteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 7, cooldown = 3f });
        waves.Add(eighteenthWave);

        Wave nineteenthWave = new Wave();
        nineteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 12, cooldown = 3f });
        nineteenthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 10, cooldown = 3f });
        waves.Add(nineteenthWave);

        Wave twentiethWave = new Wave();
        twentiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 10, cooldown = 3f });
        twentiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 12, cooldown = 3f });
        waves.Add(twentiethWave);

        Wave twentyFirstWave = new Wave();
        twentyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 15, cooldown = 2.5f });
        twentyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 6, cooldown = 3f });
        waves.Add(twentyFirstWave);

        Wave twentySecondWave = new Wave();
        twentySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 10, cooldown = 2f });
        twentySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 12, cooldown = 3f });
        twentySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 15, cooldown = 3f });
        waves.Add(twentySecondWave);

        Wave twentyThirdWave = new Wave();
        twentyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 8, cooldown = 3f });
        twentyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 18, cooldown = 2.5f });
        twentyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 8, cooldown = 3f });
        waves.Add(twentyThirdWave);

        Wave twentyFourthWave = new Wave();
        twentyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 10, cooldown = 2f });
        twentyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 15, cooldown = 3f });
        twentyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 12, cooldown = 3f });
        waves.Add(twentyFourthWave);

        //----------------------------------//
        Wave twentyFifthWave = new Wave();
        twentyFifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = tenthEnemy, count = 1, cooldown = 1.5f });
        waves.Add(twentyFifthWave);
        //----------------------------------//
        Wave twentySixthWave = new Wave();
        twentySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 7, cooldown = 2f });
        twentySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 12, cooldown = 2f });
        twentySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 5, cooldown = 4.5f });
        waves.Add(twentySixthWave);
        //----------------------------------//
        Wave twentySeventhWave = new Wave();
        twentySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 14, cooldown = 2.5f });
        twentySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 7, cooldown = 4f });
        waves.Add(twentySeventhWave);
        //----------------------------------//
        Wave twentyEighthWave = new Wave();
        twentyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 8, cooldown = 3f });
        twentyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 14, cooldown = 2.5f });
        twentyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 10, cooldown = 3.5f });
        waves.Add(twentyEighthWave);
        //----------------------------------//
        Wave twentyNinthWave = new Wave();
        twentyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 10, cooldown = 2f });
        twentyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fourthEnemy, count = 12, cooldown = 2.5f });
        twentyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 8, cooldown = 3f });
        waves.Add(twentyNinthWave);
        //----------------------------------//
        Wave thirtiethWave = new Wave();
        thirtiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 8, cooldown = 2f });
        thirtiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 14, cooldown = 2f });
        thirtiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 2, cooldown = 4f });
        waves.Add(thirtiethWave);
        //----------------------------------//
        Wave thirtyFirstWave = new Wave();
        thirtyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 15, cooldown = 2.5f });
        thirtyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 12, cooldown = 2.5f });
        thirtyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 4, cooldown = 4f });
        waves.Add(thirtyFirstWave);
        //----------------------------------//
        Wave thirtySecondWave = new Wave();
        thirtySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 10, cooldown = 2f });
        thirtySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 8, cooldown = 2.5f });
        thirtySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 8, cooldown = 3.5f });
        waves.Add(thirtySecondWave);
        //----------------------------------//
        Wave thirtyThirdWave = new Wave();
        thirtyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 9, cooldown = 3f });
        thirtyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 6, cooldown = 2f });
        thirtyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 12, cooldown = 3.5f });
        waves.Add(thirtyThirdWave);
        //----------------------------------//
        Wave thirtyFourthWave = new Wave();
        thirtyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 20, cooldown = 2f });
        thirtyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 6, cooldown = 3f });
        thirtyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 14, cooldown = 2.5f });
        waves.Add(thirtyFourthWave);
        //----------------------------------//
        Wave thirtyFifthWave = new Wave();
        thirtyFifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 16, cooldown = 2.5f });
        thirtyFifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 3, cooldown = 5f });
        waves.Add(thirtyFifthWave);
        //----------------------------------//
        Wave thirtySixthWave = new Wave();
        thirtySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 6, cooldown = 2f });
        thirtySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 12, cooldown = 3f });
        thirtySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 6, cooldown = 4f });
        waves.Add(thirtySixthWave);
        //----------------------------------//
        Wave thirtySeventhWave = new Wave();
        thirtySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 10, cooldown = 2f });
        thirtySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 14, cooldown = 3.5f });
        thirtySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 8, cooldown = 4.5f });
        waves.Add(thirtySeventhWave);
        //----------------------------------//
        Wave thirtyEighthWave = new Wave();
        thirtyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 15, cooldown = 2f });
        thirtyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 14, cooldown = 3.5f });
        thirtyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 10, cooldown = 4.5f });
        waves.Add(thirtyEighthWave);
        //----------------------------------//
        Wave thirtyNinthWave = new Wave();
        thirtyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 8, cooldown = 3f });
        thirtyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 12, cooldown = 3f });
        thirtyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 10, cooldown = 4f });
        waves.Add(thirtyNinthWave);
        //----------------------------------//
        Wave fortiethWave = new Wave();
        fortiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 9, cooldown = 2f });
        fortiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 8, cooldown = 3f });
        fortiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 12, cooldown = 4f });
        waves.Add(fortiethWave);
        //----------------------------------//
        Wave fortyFirstWave = new Wave();
        fortyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 6, cooldown = 3f });
        fortyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = fifthEnemy, count = 10, cooldown = 2.5f });
        fortyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 14, cooldown = 3f });
        fortyFirstWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 2, cooldown = 4.5f });
        waves.Add(fortyFirstWave);
        //----------------------------------//
        Wave fortySecondWave = new Wave();
        fortySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 6, cooldown = 3f });
        fortySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 12, cooldown = 2.5f });
        fortySecondWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 4, cooldown = 3f });
        waves.Add(fortySecondWave);
        //----------------------------------//
        Wave fortyThirdWave = new Wave();
        fortyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 11, cooldown = 3f });
        fortyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 10, cooldown = 2.5f });
        fortyThirdWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 8, cooldown = 3f });
        waves.Add(fortyThirdWave);
        //----------------------------------//
        Wave fortyFourthWave = new Wave();
        fortyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 5, cooldown = 2f });
        fortyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = seventhEnemy, count = 8, cooldown = 3.5f });
        fortyFourthWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 12, cooldown = 4f });
        waves.Add(fortyFourthWave);
        //----------------------------------//
        Wave fortyFifthWave = new Wave();
        fortyFifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 20, cooldown = 2f });
        fortyFifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 16, cooldown = 2f });
        fortyFifthWave.enemies.Add(new EnemySpawnData { enemyPrefab = ninethEnemy, count = 2, cooldown = 5f });
        waves.Add(fortyFifthWave);
        //----------------------------------//
        Wave fortySixthWave = new Wave();
        fortySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = thirdEnemy, count = 14, cooldown = 3f });
        fortySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 13, cooldown = 2.5f });
        fortySixthWave.enemies.Add(new EnemySpawnData { enemyPrefab = ninethEnemy, count = 5, cooldown = 5.5f });
        waves.Add(fortySixthWave);
        //----------------------------------//
        Wave fortySeventhWave = new Wave();
        fortySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 6, cooldown = 3f });
        fortySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = secondEnemy, count = 6, cooldown = 2f });
        fortySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 10, cooldown = 3.5f });
        fortySeventhWave.enemies.Add(new EnemySpawnData { enemyPrefab = ninethEnemy, count = 8, cooldown = 5.5f });
        waves.Add(fortySeventhWave);
        //----------------------------------//
        Wave fortyEighthWave = new Wave();
        fortyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = firstEnemy, count = 15, cooldown = 2f });
        fortyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 8, cooldown = 3f });
        fortyEighthWave.enemies.Add(new EnemySpawnData { enemyPrefab = ninethEnemy, count = 10, cooldown = 5f });
        waves.Add(fortyEighthWave);
        //----------------------------------//
        Wave fortyNinthWave = new Wave();
        fortyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = sixthEnemy, count = 15, cooldown = 3f });
        fortyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = eighthEnemy, count = 8, cooldown = 2.5f });
        fortyNinthWave.enemies.Add(new EnemySpawnData { enemyPrefab = ninethEnemy, count = 12, cooldown = 4.5f });
        waves.Add(fortyNinthWave);
        //----------------------------------//
        Wave fiftiethWave = new Wave();
        fiftiethWave.enemies.Add(new EnemySpawnData { enemyPrefab = eleventhEnemy, count = 1, cooldown = 6f });
        waves.Add(fiftiethWave);
        //----------------------------------//
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
