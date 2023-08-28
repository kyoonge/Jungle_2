using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeKey : MonoBehaviour
{
    private StaticsManager staticsManager;
    
    private bool isHit;
    
    private Note hitNote;
    
    public GameObject perfect, good;
    [SerializeField] private float perfectValue = 0.01f; 
    [SerializeField] private float goodValue = 0.01f;
    private SpriteRenderer perfectSprite, goodSprite, effectSpriteRenderer;
    
    private void Awake()
    {
        staticsManager = GameObject.Find("StaticsManager").GetComponent<StaticsManager>();
        perfectSprite = perfect.GetComponent<SpriteRenderer>();
        goodSprite = good.GetComponent<SpriteRenderer>();
        isHit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("note"))
        {
            isHit = true;
            hitNote = other.GetComponent<Note>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("note"))
        {
            isHit = false;

            if (!hitNote.IsHit())
            {
                hitNote.OnMissHit();
                staticsManager.AddMiss();
            }
            
            hitNote = null;
        }
    }

    public void LandJudge()
    {
        if (isHit)
        {
            if (hitNote && !hitNote.IsHit())
            {
                hitNote.OnPerfectHit();
                effectSpriteRenderer = perfectSprite;
                StartCoroutine(ShowEffect(perfect));
                UIManager.instance.panelIngameController.increaseHP(perfectValue);
                staticsManager.AddPerfect();
            }
        }
    }

    public void StayJudge()
    {
        if (isHit)
        {
            if (hitNote && !hitNote.IsHit())
            {
                hitNote.OnNormalHit();
                effectSpriteRenderer = goodSprite;
                StartCoroutine(ShowEffect(good));
                UIManager.instance.panelIngameController.increaseHP(goodValue);
                staticsManager.AddNormal();
            }
        }
    }

    private IEnumerator ShowEffect(GameObject result)
    {
        result.transform.position = transform.position + new Vector3(0, 0, 1f);
        //result.SetActive(true);
        StartCoroutine(EnterKeyEffect());
        yield return new WaitForSeconds(0.1f);
        //result.SetActive(false);
        StartCoroutine(ExitKeyEffect());
    }

    public IEnumerator EnterKeyEffect()
    {
        StopCoroutine(ExitKeyEffect());
        //effectKey.SetActive(true);
        for (float f = 0f; f < 1f; f += 0.1f)
        {
            Color c = effectSpriteRenderer.color;
            c.a = f;
            effectSpriteRenderer.color = c;
            yield return null;
        }
    }

    public IEnumerator ExitKeyEffect()
    {
        for (float f = 1f; f > 0f; f -= 0.01f)
        {
            Color c = effectSpriteRenderer.color;
            c.a = f;
            effectSpriteRenderer.color = c;
            yield return null;
        }
        //effectKey.SetActive(false);
    }
}
