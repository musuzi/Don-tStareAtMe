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
        public List<EnemyGroup> enemyGroups;//������Ϣ
        public int waveQuota;//���������ɵĵ�������
        public float spawnInterval;//���μ��
        public int spawnCount;//�������Ѿ����ɵĵ���
    }
    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;//Ҫ�ڴ�wave�����ɵ�enemy����
        public int spawnCount;//ʵ�����ɵ�����
        public GameObject enemyprefabs;
    }
    public List<Wave> Waves;
    public int currentWaveCount;

    [Header("���ɵ�������")]
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


   
    //��ʼ��һ��
     IEnumerator BeginNexWave()
    {
        yield return new WaitForSeconds(waveInterval);
        if (currentWaveCount < Waves.Count - 1  )
        {
            
            currentWaveCount++;
            CalculateWaveQuota() ;
        }
    }
    void CalculateWaveQuota()//����ÿ���ĵ�������
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in Waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        Waves[currentWaveCount].waveQuota = currentWaveQuota;
    }

    //���ɵ���
    void SpawnEnemeies()
    {
        if (Waves[currentWaveCount].spawnCount < Waves[currentWaveCount].waveQuota&&!maxEneminesReached)//�ж����������Ƿ�С�ڸò�����Ӧ�����ɵĵ����������Լ��Ƿ�ﵽ�����˵�����
        {

            foreach (var enemyGroup in Waves[currentWaveCount].enemyGroups)//����Wave�б��е�enemyGroups
            {

                if (enemyGroup.spawnCount < enemyGroup.enemyCount)//��������Ѿ����ɵ�����С��
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

    //���� ������
  
}