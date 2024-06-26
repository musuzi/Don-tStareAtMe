using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindES : MonoBehaviour
{
    private EnemySpawner Es;
    public static int TotalEnemiesDied;
    private void Start()
    {
        Es=FindObjectOfType<EnemySpawner>();
    }

    public void OnWavesEnd()
    {
        if (Es.eneminesAlives == 0 && Es.currentWaveCount < Es.Waves.Count - 1)
        {
            Debug.LogWarning(Es.eneminesAlives);
        }
    }
    public void OnenemyKilled()
    {
        TotalEnemiesDied++;
        Es.eneminesAlives--;
    }
}
