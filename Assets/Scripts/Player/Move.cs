using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSpace
{
    [System.Serializable]
    public class Move
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float xMin;
        [SerializeField] private float xMax;

        [SerializeField] private float yMin;
        [SerializeField] private float yMax;

        [SerializeField] private float paddingX = 0.05f;
        [SerializeField] private float paddingY = 0.03f;

        //Init in startMethod
        public void SetUpMoveBorders()
        {
            Camera camera = Camera.main;
            xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddingX;
            xMax = camera.ViewportToWorldPoint(new Vector3(1f, 0, 0)).x - paddingX;

            yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingY;
            yMax = camera.ViewportToWorldPoint(new Vector3(0, 1f, 0)).y - paddingY;
        }
        public void Movement(Transform transform)
        {
            float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            var newXPos = transform.position.x + deltaX;
            var newYPos = transform.position.y + deltaY;

            float xPosClamp = Mathf.Clamp(newXPos, xMin, xMax);
            float yPosClamp = Mathf.Clamp(newYPos, yMin, yMax);

            transform.position = new Vector2(xPosClamp, yPosClamp);
        }
    }
}