using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace onLand
{
    public class MovingPlate : MonoBehaviour
    {
        public float moveSpeed = 2f;
        
        private bool canMove;
        
        private Vector3 originPosition;
        
        private void Awake()
        {
            originPosition = transform.position;
        }

        private void FixedUpdate()
        {
            MoveSheet();
        }

        private void MoveSheet()
        {
            if (canMove)
            {
                var curPosition = transform.position;
                var newPosition = curPosition + transform.up * -1;
                transform.position = Vector3.Lerp(curPosition, newPosition, Time.deltaTime * moveSpeed);
            }
        }

        public void SetIsMoving(bool isMoving)
        {
            canMove = isMoving;
        }

        public void ResetPosition()
        {
            transform.position = originPosition;
        }
    }

}
