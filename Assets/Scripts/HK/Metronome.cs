using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //�ּ� ���� �� ��Ʈ�γ� �߻�
            //AkSoundEngine.PostEvent("Count", gameObject);
            Destroy(gameObject);
        }
    }

}
