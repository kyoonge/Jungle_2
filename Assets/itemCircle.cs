using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCircle : MonoBehaviour
{
    private GameObject player;
    private Animator animator;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = this.GetComponent<Animator>();
    }

    //trigger off -> 실행되면 애니메이션 실행 -> trigger on


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            AkSoundEngine.PostEvent("ItemSound", gameObject);
        }
    }

}
