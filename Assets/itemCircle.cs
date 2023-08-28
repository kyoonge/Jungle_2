using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCircle : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private float itemHp;

    private void Start()
    {
        player = GameObject.Find("Player");
        animator = this.GetComponent<Animator>();
    }

    //trigger off -> ����Ǹ� �ִϸ��̼� ���� -> trigger on


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float itemHp = 0.01f;
            this.gameObject.SetActive(false);
            AkSoundEngine.PostEvent("ItemSound", gameObject);
            UIManager.instance.panelIngameController.increaseHP(itemHp);
        }
    }

}
