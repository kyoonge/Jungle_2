using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeKey : MonoBehaviour
{
    private bool isHit;
    private Note hitNote;
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
            }
        }
    }
}
