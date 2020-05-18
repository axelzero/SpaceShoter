using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

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

        [Header("Win")]
        [SerializeField] private Transform _winPos;

        [Header("Joystick")]
        [SerializeField] private Joystick joystick = new Joystick();

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
            if (!GlobalFields.Instans.GetIsWin())
            {
                if (!GlobalFields.Instans.GetPlayerMoveByJoystick())
                {
                    float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
                    float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
                    Moving(transform, deltaX, deltaY);
                }
                else
                {
                    float deltaX = joystick.Horizontal * Time.deltaTime * speed;
                    float deltaY = joystick.Vertical * Time.deltaTime * speed;
                    Moving(transform, deltaX, deltaY);
                }
            }
            else 
            {
                var movementThisFrame = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, _winPos.position, movementThisFrame);
            }
        }
        private void Moving(Transform transform, float deltaX, float deltaY) 
        {
            var newXPos = transform.position.x + deltaX;
            var newYPos = transform.position.y + deltaY;

            float xPosClamp = Mathf.Clamp(newXPos, xMin, xMax);
            float yPosClamp = Mathf.Clamp(newYPos, yMin, yMax);

            transform.position = new Vector2(xPosClamp, yPosClamp);
        }
    }
}