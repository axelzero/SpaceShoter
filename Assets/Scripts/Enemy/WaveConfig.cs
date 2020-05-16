using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpace
{
    [CreateAssetMenu(fileName = "Wave Config", menuName = "Create Enemy Weve Config")]
    public class WaveConfig : ScriptableObject
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject pathPrefab;
        [SerializeField] private float timeBetweenSpawns = 0.5f;
        [SerializeField] private float spawnRandomFactor = 0.3f;
        [SerializeField] private int numberOfEnemies = 10;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private int health = 20;

        [Space(20)]
        [SerializeField] private float delayBeforeWave = 3f;
        [SerializeField] private bool shooting = true;

        public GameObject GetEnemyPrefab() { return enemyPrefab; }
        public List<Transform> GetWayPoints() 
        {
            var waveWaypoints = new List<Transform>();
            foreach (Transform child in pathPrefab.transform) 
            {
                waveWaypoints.Add(child);
            }
            return waveWaypoints;
        }
        public float GetTiemBetweenSpawn() { return timeBetweenSpawns; }
        public float GetSpawnRandomFactor() { return spawnRandomFactor; }
        public int GetNumberOfEnemies() { return numberOfEnemies; }
        public float GetSpeed() { return moveSpeed; }
        public float GetDelay() { return delayBeforeWave; }
        public int GetHealth() { return health; }
        public bool GetShooting() { return shooting; }
    }
}