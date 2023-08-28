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

    private void Update()
    {
        isDetectObjectsAhead();
    }

    private bool isDetectObjectsAhead()
    {
        // 플레이어 바로 앞의 박스 캐스트 수행
        Vector2 detectionOrigin = transform.position + DetectDirection * detectionBoxSize.x * 0.5f; // 박스 캐스트 시작 위치 계산
        Collider[] hitColliders = Physics.OverlapBox(detectionOrigin, detectionBoxSize);
        //Debug.Log("DetectObject ");

        // 충돌한 오브젝트 처리
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("item"))
            {
                collider.gameObject.SetActive(false);
                GameObject _item = Instantiate(item, collider.transform.position, Quaternion.identity);
                //collider.gameObject.transform.position
                Debug.Log("item: " + collider.gameObject.name);
                StartCoroutine( DeleteObjectAfterDelay(1f, _item));
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        // 디버그용으로 검출 박스를 그리는 코드 (Scene 뷰에서만 보임)
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
