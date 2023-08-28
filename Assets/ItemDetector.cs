using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public GameObject item;

    [Header("FrontScan")]
    public Vector3 detectionBoxSize = new Vector3(20f, 5f,1f);
    public LayerMask detectionLayer;
    public Vector3 DetectDirection;
    public float destroyDelay = 2.3f;

    private void Update()
    {
        isDetectObjectsAhead();
    }

    private bool isDetectObjectsAhead()
    {
        // �÷��̾� �ٷ� ���� �ڽ� ĳ��Ʈ ����
        Vector3 detectionOrigin = transform.position + DetectDirection * detectionBoxSize.x * 0.5f; // �ڽ� ĳ��Ʈ ���� ��ġ ���
        Collider[] hitColliders = Physics.OverlapBox(detectionOrigin, detectionBoxSize);
        //Debug.Log("DetectObject ");

        // �浹�� ������Ʈ ó��
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("item"))
            {
                collider.gameObject.SetActive(false);
                Vector3 colliderPos = collider.transform.position;
                GameObject _item = Instantiate(item, new Vector3(colliderPos.x, colliderPos.y, transform.position.z), Quaternion.identity);
                //collider.gameObject.transform.position
                Debug.Log("item: " + collider.gameObject.name + ", "+collider.transform.position);
                StartCoroutine( DeleteObjectAfterDelay(destroyDelay, _item));
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

    private IEnumerator DeleteObjectAfterDelay(float delay, GameObject item)
    {
        yield return new WaitForSeconds(delay);

        if (item != null)
        {
            Destroy(item);
        }
    }
}
