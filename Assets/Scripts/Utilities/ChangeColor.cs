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
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.75f, 0.75f, 0.5f);
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
