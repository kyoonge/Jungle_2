using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color originColor;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer.color;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = originColor;
        }
    }
}
