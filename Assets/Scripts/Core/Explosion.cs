using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public class Explosion
    {
        private GameObject explosionPrefab;
        private float duration = 1f;
        private Vector3 euler;
        public void Explos(Transform transform) 
        {
            var global = GlobalFields.Instans;
            explosionPrefab = global.GetExplosionPrefab(); // Get prefab

            euler = new Vector3(0f, 0f, Random.Range(-180f, 180f)); // Set random z

            var explosion = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.Euler(euler), global.GetSpawnHolder());

            ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();

            if (particleSystem != null) // If Particle System
            {
                duration = particleSystem.main.duration;
            }
            else                        // If Animation
            {
                Animator anim = explosion.GetComponent<Animator>();
                duration = anim.GetCurrentAnimatorStateInfo(0).length;
            }

            GameObject.Destroy(explosion.gameObject, duration);
        }
    }
}