using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSheetInvisible : MonoBehaviour
{ 
    private void Start()
    {
        ChangeAlphaInChildrenObjects(transform);
    }

    private void ChangeAlphaInChildrenObjects(Transform parent)
    {
        foreach (Transform child in parent)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                Color newColor = spriteRenderer.color;
                newColor.a = 0f;
                spriteRenderer.color = newColor;
            }

            // ��������� �ڽ� ������Ʈ Ž��
            if (child.childCount > 0)
            {
                ChangeAlphaInChildrenObjects(child);
            }
        }
    }
}