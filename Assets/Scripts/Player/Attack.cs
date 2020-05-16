using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace PlayerSpace
{
    [System.Serializable]
    public class Attack
    {
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private float laserSpeed = 10f;
        [SerializeField] private float instatiateSpeed = 0.1f;


        public IEnumerator Fire(Transform transform) 
        {
            var global = GlobalFields.Instans;
            while (true)
            {
                if (Input.GetButton("Fire1"))
                {
                    GameObject laser = GameObject.Instantiate(laserPrefab, transform.position, Quaternion.identity, global.GetSpawnHolder());
                    laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
                    yield return new WaitForSeconds(instatiateSpeed);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}