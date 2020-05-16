using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GlobalFields : MonoBehaviour
    {
                         private static GlobalFields instans;
        [SerializeField] private Transform spawnHolder;
        [SerializeField] private GameObject explosionPrefab;

        public static GlobalFields Instans { get => instans; }

        private void Awake()
        {
            instans = this;
        }
        public GameObject GetExplosionPrefab() 
        {
            return explosionPrefab;
        }
        public Transform GetSpawnHolder() 
        {
            return spawnHolder;
        }
    }
}