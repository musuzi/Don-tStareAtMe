using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    [System.Serializable]

    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;//敌人信息
        public int waveQuota;//敌人总数
        public float spawnInterval;//波次间隔
        public int spawnCount;//
    }
    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyprefabs;
    }
    public List<Wave> Waves;
    public int currentWaveCount;

    [Header("生成敌人属性")]
    float spawnTimer=0;
    public int eneminesAlives;
    public int maxEnemines;
    public bool maxEneminesReached = false;
    public float waveInterval;
    void CalculateWaveQuota()//计算每波的敌人数量
    {
        int currentWaveQuota = 0;
        foreach(var enemyGroup in Waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        Waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }
    private void Update()
    {
        if (currentWaveCount < Waves.Count && Waves[currentWaveCount].spawnCount==0)
        {
            StartCoroutine(BeginNexWave());
        }
        spawnTimer += Time.deltaTime;
        if (spawnTimer > Waves[currentWaveCount].spawnInterval)
        {spawnTimer=0;  SpawnEnemeies(); }
    }
    private void Start()
    {
        CalculateWaveQuota();
    }

    IEnumerator BeginNexWave()
    {
        yield return new WaitForSeconds(waveInterval);
        if (currentWaveCount < Waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota() ;
        }
    }


    void SpawnEnemeies()
    {
        if (Waves[currentWaveCount].spawnCount < Waves[currentWaveCount].waveQuota&&!maxEneminesReached)
        {

            foreach (var enemyGroup in Waves[currentWaveCount].enemyGroups)
            {

                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {

                    if (eneminesAlives >= maxEnemines)
                    {

                        maxEneminesReached = true;
                        return;
                    }

                    Vector2 spawnPosition = new Vector2(player.position.x + Random.Range(-6f, 6f), player.position.y + Random.Range(-6f, 6f));
                    Instantiate(enemyGroup.enemyprefabs, spawnPosition, Quaternion.identity);


                    enemyGroup.spawnCount++;
                    Waves[currentWaveCount].spawnCount++;
                    eneminesAlives++;
                }
            }
        }
        if (eneminesAlives < maxEnemines)
        {
            maxEneminesReached = false;
        }
    }
    public void OnenemyKilled()
    {
        eneminesAlives--;
    }
}