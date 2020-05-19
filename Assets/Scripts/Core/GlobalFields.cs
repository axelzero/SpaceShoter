using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManager;
using MenuUI;
using EnemySpace;

namespace Core
{
    public class GlobalFields : MonoBehaviour
    {
        private static GlobalFields instans;
        [SerializeField] private Transform spawnHolder;

        [Header("Effects")]
        [SerializeField] private GameObject explosionPrefab;

        [Header("Audio")]
        [SerializeField] private AudioClip deathClip;
        [SerializeField] private AudioClip shootEnemyClip;
        [SerializeField] private AudioClip shootPlayerClip;
        [SerializeField, Range(0f, 1f)] private float volumeDie = 0.7f;
        [SerializeField, Range(0f, 1f)] private float volumeEnemyShoot = 0.15f;
        [SerializeField, Range(0f, 1f)] private float volumePlayerShoot = 0.15f;

        [Header("Managers")]
        [SerializeField] private Manager levelManager;

        [Header("UI")]
        [SerializeField] private GameObject GameOverUI;
        [SerializeField] private GameObject WinUI;

        [Header("Player")]
        [SerializeField] private List<ShipInfo> shipInfo;
        [SerializeField] private bool byJoystick = true;
        [SerializeField] private bool joystickOnOff = true;
        [SerializeField] private GameObject joystickGO;
        [SerializeField] private bool _isWin = false;

        [Header("Enemy")]
        [SerializeField] private EnemySpawner enemySpawner;

        public static GlobalFields Instans { get => instans; }

        private void Awake() 
        { 
            instans = this;
            levelManager = FindObjectOfType<Manager>();
            if (levelManager == null) 
            {
                var _delta = new GameObject("LevelManager").AddComponent<Manager>();

                levelManager = _delta.GetComponent<Manager>();
            }
        }
        public GameObject GetExplosionPrefab() { return explosionPrefab; }
        public Transform GetSpawnHolder() { return spawnHolder; }
        public AudioClip GetDeathClip() { return deathClip; }
        public AudioClip GetEnemyShootClip() { return shootEnemyClip; }
        public AudioClip GetPlayerShootClip() { return shootPlayerClip; }
        public float GetVolumeDie() { return volumeDie; }
        public float GetVolumeEnemyShoot() { return volumeEnemyShoot; }
        public float GetVolumePlayerShoot() { return volumePlayerShoot; }
        public Manager GetLevelManager() { return levelManager; }
        public GameObject GetGameOverUI() { JoystickOnOff(); return GameOverUI;  }
        public GameObject GetWinUI() { return WinUI; }
        public List<ShipInfo> GetShipInfoList() { return shipInfo; }
        public bool GetPlayerMoveByJoystick() { return byJoystick; }
        public void JoystickOnOff() 
        {
            if (joystickOnOff)
            {
                joystickOnOff = false;
                joystickGO.SetActive(joystickOnOff);
            }
            else 
            {
                joystickOnOff = true;
                joystickGO.SetActive(joystickOnOff);
            }
        }
        public bool GetIsWin() { return _isWin; }
        public void SetIsWin() { _isWin = true; JoystickOnOff(); }
        public EnemySpawner GetEnemySpawner() { return enemySpawner; }
    }
}