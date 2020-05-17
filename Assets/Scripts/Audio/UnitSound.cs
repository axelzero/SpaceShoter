using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Audio
{
    [System.Serializable]
    public class UnitSound 
    {
        private GlobalFields global;
        private AudioClip dieClip;
        private AudioClip shootClip;
        private float volumeDie;
        private float volumePlayerShoot;
        private float volumeEnemyShoot;

        public void Init() 
        {
            global = GlobalFields.Instans;

            volumeDie = global.GetVolumeDie();
            volumeEnemyShoot = global.GetVolumeEnemyShoot();
            volumePlayerShoot = global.GetVolumePlayerShoot();
        }

        public void AudioPlayDie() 
        {
            dieClip = global.GetDeathClip();
            AudioSource.PlayClipAtPoint(dieClip, Camera.main.transform.position, volumeDie);
        }
        public void AudioPlayEnemyShoot() 
        {
            shootClip = GlobalFields.Instans.GetEnemyShootClip();
            AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, volumeEnemyShoot);
        }
        public void AudioPlayPlayerShoot()
        {
            shootClip = GlobalFields.Instans.GetPlayerShootClip();
            AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, volumePlayerShoot);
        }

        public IEnumerator WaitForGetRef()
        {
            global = GlobalFields.Instans;
            while (global == null)
            {
                global = GlobalFields.Instans;
                yield return null;
            }
        }
    }
}