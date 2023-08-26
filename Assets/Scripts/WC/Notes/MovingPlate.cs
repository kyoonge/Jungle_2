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
        private void Awake()
        {
            var curPosition = transform.position;
        }

        private void FixedUpdate()
        {
            var curPosition = transform.position;
            var newPosition = curPosition + transform.up * -1;
            transform.position = Vector3.Lerp(curPosition, newPosition, Time.deltaTime * moveSpeed);
        }
    }

}
