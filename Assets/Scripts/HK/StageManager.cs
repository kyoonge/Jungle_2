using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject sheetPrefab1;
    public GameObject sheetPrefab2;
    public GameObject sheetPrefab3;
    public GameObject sheetPrefab4;

    public AudioSource TestSong;
    public AudioSource MainSong;
    public AudioSource Count;

    public static StageManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayStage1()
    {
        Resources.Load<GameObject>("prefabs/TestEasyPrefabs");
        Invoke("CountDown", 3f);
        TestSong.Play();
    }

    public void PlayStage2()
    {
        Resources.Load<GameObject>("prefabs/TestHardPrefabs");
        Invoke("CountDown", 3f);
        TestSong.Play();
    }

    public void PlayStage3()
    {
        Resources.Load<GameObject>("prefabs/TestMainEasyPrefabs");
        Invoke("CountDown", 3f);
        TestSong.Play();
    }

    public void PlayStage4()
    {
        Resources.Load<GameObject>("prefabs/TestMainHardPrefabs");
        Invoke("CountDown", 3f);
        TestSong.Play();
    }

    public void CountDown()
    {
        Count.Play();
    }

}

