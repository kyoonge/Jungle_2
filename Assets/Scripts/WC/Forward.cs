using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public float moveSpeed = 2f;
    private void Awake()
    {
        var curPosition = transform.position;
    }

    private void FixedUpdate()
    {
        var curPosition = transform.position;
        var newPosition = curPosition + transform.up;
        transform.position = Vector3.Lerp(curPosition, newPosition, Time.deltaTime * moveSpeed);
    }
}
