using System;
using System.Collections;
using System.Collections.Generic;
using onLand;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public AudioSource musicSource;
    
    public GameObject metronomeGO;
    private onLand.Metronome metronome;
    
    public GameObject sheet;
    private MovingPlate movingPlate;

    private bool isPaused;

    private void Awake()
    {
        metronome = metronomeGO.GetComponent<onLand.Metronome>();
        movingPlate = sheet.transform.Find("MovingPlate").GetComponent<MovingPlate>();
    }

    private void Start()
    {
        musicSource.Play();
        musicSource.Pause();
        metronome.SetMetronomeOn(false);
        
        movingPlate.SetIsMoving(false);
        
        isPaused = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            musicSource.UnPause();
            metronome.SetMetronomeOn(true);
            
            movingPlate.SetIsMoving(true);
            
            isPaused = false;
        }
        else
        {
            musicSource.Pause();
            metronome.SetMetronomeOn(false);
            
            movingPlate.SetIsMoving(false);
            
            isPaused = true;
        }
    }

    private void Restart()
    {
        musicSource.Stop();
        metronome.SetMetronomeOn(false);
        
        movingPlate.SetIsMoving(false);
        
        movingPlate.ResetPosition();
        for (int i = 0; i < movingPlate.transform.childCount; i++)
        {
            var measure = movingPlate.transform.GetChild(i);
            for (int j = 0; j < measure.childCount; j++)
            {
                var bar = measure.GetChild(j);
                for (int k = 0; k < bar.childCount; k++)
                {
                    var note = bar.GetChild(k).GetComponent<Note>();
                    if (note)
                    {
                        note.ResetNote();    
                    }
                }
            }
        }
        // CountDown
        
        musicSource.Play();
        metronome.SetMetronomeOn(true);
        
        movingPlate.SetIsMoving(true);
    }
}
