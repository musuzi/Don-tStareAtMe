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
        public int waveQuota;//波次中生成的敌人总数
        public float spawnInterval;//波次间隔
        public int spawnCount;//波次中已经生成的敌人
    }
    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;//要在此wave中生成的enemy数量
        public int spawnCount;//实际生成的数量
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

    private void Start()
    {
        eneminesAlives = 0;
        CalculateWaveQuota();
    }

    private void Update()
    {
        if (currentWaveCount < Waves.Count-1 && Waves[currentWaveCount].spawnCount==0&&eneminesAlives==0)
        {
            StartCoroutine(BeginNexWave());
        }
        spawnTimer += Time.deltaTime;

        if (spawnTimer > Waves[currentWaveCount].spawnInterval)
        { spawnTimer=0;  SpawnEnemeies(); }
    }


   
    //开始下一波
     IEnumerator BeginNexWave()
    {
        yield return new WaitForSeconds(waveInterval);
        if (currentWaveCount < Waves.Count - 1  )
        {
            
            currentWaveCount++;
            CalculateWaveQuota() ;
        }
    }
    void CalculateWaveQuota()//计算每波的敌人数量
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in Waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        Waves[currentWaveCount].waveQuota = currentWaveQuota;
    }

    //生成敌人
    void SpawnEnemeies()
    {
        if (Waves[currentWaveCount].spawnCount < Waves[currentWaveCount].waveQuota&&!maxEneminesReached)//判断生成数量是否小于
        {

            foreach (var enemyGroup in Waves[currentWaveCount].enemyGroups)
            {

                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    Debug.LogWarning("生成敌人中");
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

    //敌人 死亡后
  
}