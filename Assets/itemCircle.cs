using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCircle : MonoBehaviour
{
    private GameObject player;
    //private Animator animator;

    private void Start()
    {
        player = GameObject.Find("Player");
        //animator = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Eat Item");
        }
    }

}
