using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrashcan : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("item"))
        {
            Debug.Log("cube");
            collision.gameObject.SetActive(false);

        }
    }
}
