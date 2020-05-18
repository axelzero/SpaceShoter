using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
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
            var gloabal = GlobalFields.Instans;

            int countEnemy = currentWave.GetNumberOfEnemies();
            yield return new WaitForSeconds(currentWave.GetDelay());
            for (int i = 0; i < countEnemy; i++)
            {
                var enemyPrefab = currentWave.GetEnemyPrefab();
                var pos = currentWave.GetWayPoints()[0].transform.position;
                var holder = gloabal.GetSpawnHolder();

                var enemyGo = Instantiate(enemyPrefab, pos, Quaternion.identity, holder);
                var enemy = enemyGo.GetComponent<Enemy>();
                enemy.SetScore(currentWave.GetScore());
                enemy.GetPath().SetWaveConfig(currentWave);
                enemy.SetHealth(currentWave.GetHealth());
                enemy.EnemyShooting.SetShooting(currentWave.GetShooting());
                yield return new WaitForSeconds(currentWave.GetTiemBetweenSpawn());
            }
        }
    }
}