using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace onLand
{
    public class Key : MonoBehaviour
    {
        private Color originColor;
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private GameObject effectKey;
        private SpriteRenderer effectSpriteRenderer;
        
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originColor = spriteRenderer.color;
            effectSpriteRenderer = effectKey.GetComponent<SpriteRenderer>();
            effectKey.SetActive(false);
            
        }
        private void OnCollisionEnter2D(Collision2D other)
        {   
            if (other.gameObject.CompareTag("Player"))
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(EnterKeyEffect());
            }
        }
        private void OnCollisionExit2D(Collision2D other)
        {   
            if (other.gameObject.CompareTag("Player"))
            {
                GetComponent<SpriteRenderer>().color = originColor;
                StartCoroutine(ExitKeyEffect());
                //effectKey.SetActive(false);
            }
        }

        public IEnumerator EnterKeyEffect()
        {
            StopCoroutine(ExitKeyEffect());
            effectKey.SetActive(true);
            for (float f = 0f; f < 1f; f += 0.1f)
            {
                Color c = effectSpriteRenderer.material.color;
                c.a = f;
                effectSpriteRenderer.material.color = c;
                yield return null;
            }
        }

        public IEnumerator ExitKeyEffect()
        {
            for (float f = 1f; f > 0f; f -= 0.01f)
            {
                Color c = effectSpriteRenderer.material.color;
                c.a = f;
                effectSpriteRenderer.material.color = c;
                yield return null;
            }
            effectKey.SetActive(false);
        }
    }
}

