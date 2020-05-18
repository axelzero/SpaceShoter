using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Audio;

namespace PlayerSpace
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Move move = new Move();
        [SerializeField] private Attack attack = new Attack();
        [SerializeField] private Health health = new Health();
                         private UnitSound unitSound = new UnitSound();
                         private Explosion explosion = new Explosion();
                         private Coroutine attacCoroutine;
                         private SpriteRenderer spriteShip;

        private void Start()
        {
            health.Init();
            unitSound.Init();
            move.SetUpMoveBorders();
            attacCoroutine = StartCoroutine(attack.Fire(transform,unitSound));

        }
        private void Update()
        {
            move.Movement(transform);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var damage = other.GetComponent<Damage>();
            var enemy = other.GetComponent<EnemySpace.Enemy>();
           
            if (damage)
            {
                health.Healths -= damage.GetDamage();
                Destroy(other.gameObject);
            } 
            else if (enemy) 
            {
                int hp = health.Healths;
                if (!enemy.IsItBoss())
                {
                    enemy.Сrash(ref hp);
                    health.Healths = hp;
                }
            }
            health.SetDamage();
            PlayerDie();
        }
        private void PlayerDie() 
        {
            if (health.Healths <= 0) 
            {
                unitSound.AudioPlayDie();
                explosion.Explos(transform);
                Destroy(this.gameObject);

                var global = GlobalFields.Instans;
                var levelManager = FindObjectOfType<LevelManager.Manager>();
                levelManager.GameOver(global.GetGameOverUI());
            }
        }
        private void OnDestroy()
        {
            if(attacCoroutine != null) StopCoroutine(attacCoroutine);
        }
        public void SetShip(Sprite sprite) 
        {
            spriteShip = GetComponent<SpriteRenderer>();
            spriteShip.sprite = sprite;
        }
    }
}