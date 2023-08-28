using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace onLand
{
    public class Key : MonoBehaviour
    {
        private Color originColor;
        private SpriteRenderer spriteRenderer;
        
        [SerializeField]
        private GameObject effectKey;
        private SpriteRenderer effectSpriteRenderer;
        
        [SerializeField]
        private AudioSource keySound;

        
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originColor = spriteRenderer.color;
            effectSpriteRenderer = effectKey.GetComponent<SpriteRenderer>();
            //effectKey.SetActive(false);
            Color c = effectSpriteRenderer.material.color;
            c.a = 0;
            effectSpriteRenderer.material.color = c;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {   
            if (other.gameObject.CompareTag("Player"))
            {
                keySound.Play();
                RumbleManager.instance.RumblePulse(1f, 1f, 0.1f);
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
            //effectKey.SetActive(true);
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
            //effectKey.SetActive(false);
        }
    }
}

