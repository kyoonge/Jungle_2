using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour
{
    public AudioSource audioSource;
    public double bpm = 90f;

    double nextTick = 0.0F; // The next tick in dspTime
    double sampleRate = 0.0F; 
    bool ticked = false;

    void Start() {
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;

        nextTick = startTick + (60.0 / bpm);
    }

    void LateUpdate() {
        if ( !ticked && nextTick >= AudioSettings.dspTime ) {
            ticked = true;
            OnTick();
            //BroadcastMessage( "OnTick" );
        }
    }

    // Just an example OnTick here
    void OnTick() {
        //Debug.Log( "Tick" );
        audioSource.Play();
        // GetComponent<AudioSource>().Play();
    }

    void FixedUpdate() {
        double timePerTick = 60.0f / bpm;
        double dspTime = AudioSettings.dspTime;

        while ( dspTime >= nextTick ) {
            ticked = false;
            nextTick += timePerTick;
        }

    }
}
