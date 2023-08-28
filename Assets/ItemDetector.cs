using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public GameObject item;

    [Header("FrontScan")]
    public Vector2 detectionBoxSize = new Vector2(20f, 5f);
    public LayerMask detectionLayer;
    public Vector3 DetectDirection;

    private void Start()
    {
        //item = transform.Find("Item").gameObject;
    }

    private bool isDetectObjectsAhead()
    {
        // �÷��̾� �ٷ� ���� �ڽ� ĳ��Ʈ ����
        Vector2 detectionOrigin = transform.position + DetectDirection * detectionBoxSize.x * 0.5f; // �ڽ� ĳ��Ʈ ���� ��ġ ���
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(detectionOrigin, detectionBoxSize, 0f);
        //Debug.Log("DetectObject ");

        // �浹�� ������Ʈ ó��
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("item"))
            {
                //collider.gameObject.transform.position
                Debug.Log("item: " + collider.gameObject.name);
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        // ����׿����� ���� �ڽ��� �׸��� �ڵ� (Scene �信���� ����)
        Vector3 detectionOrigin = transform.position + DetectDirection * detectionBoxSize.x * 0.5f;
        Gizmos.DrawWireCube(detectionOrigin, detectionBoxSize);
    }
}
