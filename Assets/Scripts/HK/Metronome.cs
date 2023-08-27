using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //주석 해제 시 메트로놈 발생
            //AkSoundEngine.PostEvent("Count", gameObject);
            Destroy(gameObject);
        }
    }

}
