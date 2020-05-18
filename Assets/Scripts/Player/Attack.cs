using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Audio;

namespace PlayerSpace
{
    [System.Serializable]
    public class Attack
    {
        [SerializeField] private GameObject laserPrefab;
        [SerializeField] private float laserSpeed = 10f;
        [SerializeField] private float instatiateSpeed = 0.1f;
        [SerializeField] private bool autoFire = false;


        public IEnumerator Fire(Transform transform, UnitSound unitSound) 
        {
            var global = GlobalFields.Instans;
            while (true)
            {
                if ((Input.GetButton("Fire1") || autoFire))
                {
                    GameObject laser = GameObject.Instantiate(laserPrefab, transform.position, Quaternion.identity, global.GetSpawnHolder());
                    laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
                    unitSound.AudioPlayPlayerShoot();
                    yield return new WaitForSeconds(instatiateSpeed);
                }
                yield return new WaitForSeconds(0.01f);
                if (GlobalFields.Instans.GetIsWin()) 
                {
                    break;
                }
            }
        }
    }
}