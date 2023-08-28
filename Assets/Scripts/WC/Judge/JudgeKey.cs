using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeKey : MonoBehaviour
{
    private bool isHit;
    private GameObject hitNote;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("note"))
        {
            isHit = true;
            hitNote = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("note"))
        {
            isHit = false;
            hitNote = null;
        }
    }

    public void LandJudge()
    {
        if (isHit)
        {
            var noteSR = hitNote.GetComponent<SpriteRenderer>();
            if (noteSR != null)
            {
                noteSR.color = Color.green;
            }
        }
    }
}
