using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpace
{
    [System.Serializable]
    public class EnemyPathing
    {
        private WaveConfig waveConfig;
        private List<Transform> wayPoints;
        private float moveSpeed = 2f;
        private int wayPointIndex = 0;
        private Transform transform;

        public void Init(Transform transform)
        {
            wayPoints = waveConfig.GetWayPoints();
            moveSpeed = waveConfig.GetSpeed();
            this.transform = transform;
            this.transform.position = wayPoints[wayPointIndex].position;
        }

        public void SetWaveConfig(WaveConfig config) 
        {
            waveConfig = config;
        }

        public void MoveTo()
        {
            if (wayPointIndex < wayPoints.Count)
            {
                var targetPosition = wayPoints[wayPointIndex].transform.position;
                var movementThisFrame = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

                if (transform.position == targetPosition)
                {
                    wayPointIndex++;
                }
            }
            else
            {
                //GlobalFields.Instans.GetEnemySpawner().EnemyOutGame();
                GameObject.Destroy(transform.gameObject);
            }
        }
        public float GetSpeed() 
        {
            return moveSpeed;
        }
    }
}