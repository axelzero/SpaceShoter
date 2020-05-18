using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Audio;

namespace EnemySpace
{
    [System.Serializable]
    public class EnemyShooting 
    {
                         private bool shooting = true;
        [SerializeField] private GameObject enemyLaserPregab;
        [SerializeField] private float laserSpeed = 10f;
                         private float shotCounter;
        [SerializeField] private float minTimeBetweenShots = 0.2f;
        [SerializeField] private float maxTimeBetweenShots = 3f;
                         private Vector3 shift = new Vector3(0f,-1f,0f);

        private void GetRandomTime() 
        {
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
        public IEnumerator Shooting(Transform transform, float enemySpeed, UnitSound unitSound) 
        {
            while (shooting) 
            {
                GetRandomTime();
                Fire(transform, enemySpeed, unitSound);
                yield return new WaitForSeconds(shotCounter);
            }
        }

        private void Fire(Transform transform, float enemySpeed, UnitSound unitSound)
        {
            var global = GlobalFields.Instans;
            GameObject laser = GameObject.Instantiate(enemyLaserPregab, transform.position + shift, Quaternion.identity, global.GetSpawnHolder());
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -laserSpeed - enemySpeed);
            unitSound.AudioPlayEnemyShoot();
        }
        public void SetShooting(bool shooting) 
        {
            this.shooting = shooting;
        }
    }
}