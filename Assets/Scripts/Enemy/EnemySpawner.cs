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
    private void Start()
    {
        CalculateWaveQuota();
        SpawnEnemeies();
    }
    void SpawnEnemeies()
    {
        if (Waves[currentWaveCount].spawnCount < Waves[currentWaveCount].waveQuota)
        {
            foreach(var enemyGroup in Waves[currentWaveCount].enemyGroups)
            {
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    Vector2 spawnPosition = new Vector2(player.position.x + Random.Range(-50f, 50f), player.position.y + Random.Range(-50f, 50f));
                    Instantiate(enemyGroup.enemyprefabs, spawnPosition, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    Waves[currentWaveCount].spawnCount++;
                }
            }
        }
    }
}