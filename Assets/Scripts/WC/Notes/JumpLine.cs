using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLine : MonoBehaviour
{
    private float posY;

    private void Awake()
    {
        posY = transform.position.y;
    }

    private void Start()
    {
        // cos(30deg) = cos(0.5236rad)
        var newZ = Mathf.Cos((1f / 6f) * Mathf.PI) * posY;
        // sin(30deg) = 0.5
        var newY = 0.5f * posY;
        
        transform.position = new Vector3(transform.position.x, newY, newZ);
    }
}
