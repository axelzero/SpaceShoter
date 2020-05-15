using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpace
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<WaveConfig> waveConfig;
        [SerializeField] private bool looping = false;

        private IEnumerator Start()
        {
            do
            {
                yield return StartCoroutine(SpawnAllWaves());
            } 
            while (looping);
            
        }
        private IEnumerator SpawnAllWaves()
        {
            
            int count = waveConfig.Count;
            for (int i = 0; i < count; i++)
            {
                yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfig[i]));
            }
        }

        private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
        {
            int countEnemy = currentWave.GetNumberOfEnemies();
            yield return new WaitForSeconds(currentWave.GetDelay());
            for (int i = 0; i < countEnemy; i++)
            {
                var enemy = Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWayPoints()[0].transform.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().GetPath().SetWaveConfig(currentWave);
                yield return new WaitForSeconds(currentWave.GetTiemBetweenSpawn());
            }
        }
    }
}