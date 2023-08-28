using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    private bool isHit;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isHit = false;
    }

    public void OnPerfectHit()
    {
        isHit = true;
        spriteRenderer.color = Color.green;
        AkSoundEngine.PostEvent("NoteSound", gameObject);
    }
    
    public void OnNormalHit()
    {
        isHit = true;
        spriteRenderer.color = Color.yellow;
        AkSoundEngine.PostEvent("NoteSound", gameObject);
    }
    
    public bool IsHit()
    {
        return isHit;
    }
    
    public void ResetNote()
    {
        isHit = false;
        spriteRenderer.color = Color.red;//new Color(207, 106, 106);
    }
}
