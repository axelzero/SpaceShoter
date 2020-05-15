using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpace
{
    [System.Serializable]
    public class EnemyShooting 
    {
        [SerializeField] private bool shooting = true;
        [SerializeField] private GameObject enemyLaserPregab;
        [SerializeField] private float laserSpeed = 10f;
        [SerializeField] private float shotCounter;
        [SerializeField] private float minTimeBetweenShots = 0.2f;
        [SerializeField] private float maxTimeBetweenShots = 3f;
                         private Vector3 shift = new Vector3(0f,-1f,0f);

        private void Init() 
        {
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
        public IEnumerator Shooting(Transform transform, float enemySpeed) 
        {
            while (shooting) 
            {
                Init();
                Fire(transform, enemySpeed);
                yield return new WaitForSeconds(shotCounter);
            }
        }

        private void Fire(Transform transform, float enemySpeed)
        {
            GameObject laser = GameObject.Instantiate(enemyLaserPregab, transform.position + shift, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -laserSpeed - enemySpeed);
        }
    }
}