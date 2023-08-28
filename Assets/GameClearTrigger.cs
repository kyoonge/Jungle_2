using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("gameclear"))
        {
            Debug.Log(collision.name);
            UIManager.instance.GameClear();
        }
    }
}
