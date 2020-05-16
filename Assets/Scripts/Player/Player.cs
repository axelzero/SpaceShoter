using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace PlayerSpace
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Move move = new Move();
        [SerializeField] private Attack attack = new Attack();
        [SerializeField] private Health health = new Health();
                         private Explosion explosion = new Explosion();
                         private Coroutine attacCoroutine;

        private void Start()
        {
            move.SetUpMoveBorders();
            attacCoroutine = StartCoroutine(attack.Fire(transform));
        }
        private void Update()
        {
            move.Movement(transform);
        }
        private void OnDestroy()
        {
            StopCoroutine(attacCoroutine);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var damage = other.GetComponent<Damage>();
            if (!damage) { return; }
            health.Healths -= damage.GetDamage();
            damage.Hit();
            PlayerDestroy();
        }
        private void PlayerDestroy() 
        {
            if (health.Healths <= 0) 
            {
                explosion.Explos(transform);
                Destroy(this.gameObject);
            }
        }
    }
}