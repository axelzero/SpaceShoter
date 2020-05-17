using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Audio;

namespace EnemySpace
{
    public class Enemy : MonoBehaviour
    {
                         private Health         health = new Health();
                         private EnemyPathing   enemyPathing = new EnemyPathing();
        [SerializeField] private Explosion      explosion = new Explosion();
        [SerializeField] private EnemyShooting  shooting = new EnemyShooting();
                         private UnitSound      unitSound = new UnitSound();
                         private int            crachByCollision = 5;

        public EnemyShooting EnemyShooting => shooting;
        private void Start()
        {
            unitSound.Init();
            enemyPathing.Init(transform);
            StartCoroutine(shooting.Shooting(transform,enemyPathing.GetSpeed(), unitSound));
        }
        private void Update()
        {
            enemyPathing.MoveTo();
        }
        public EnemyPathing GetPath() 
        {
            return enemyPathing;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            Damage damage = other.gameObject.GetComponent<Damage>();
            if (!damage) { return; }
            Hit(damage);
        }
        public void SetHealth(int healthPoints) 
        {
            health.Healths = healthPoints;
        }
        private void Hit(Damage damage)
        {
            health.Healths -= damage.GetDamage();
            if (health.Healths <= 0)
            {
                explosion.Explos(transform);
                unitSound.AudioPlayDie();
                Destroy(gameObject);
            }
        }
        public void Сrash(ref int health) 
        {
            health -= crachByCollision;
            explosion.Explos(transform);
            unitSound.AudioPlayDie();
            Destroy(gameObject);
        }
    }
}