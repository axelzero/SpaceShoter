using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace EnemySpace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Health health = new Health(); //float health = 30;
        [SerializeField] private EnemyShooting shooting = new EnemyShooting();
                         private EnemyPathing enemyPathing = new EnemyPathing();

        private void Start()
        {
            enemyPathing.Init(transform);
           // shooting.Init();
            StartCoroutine(shooting.Shooting(transform,enemyPathing.GetSpeed()));
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

        private void Hit(Damage damage)
        {
            damage.Hit();
            health.Healths -= damage.GetDamage();
            if (health.Healths <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}