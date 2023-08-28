using UnityEngine;
using System.Collections;

namespace onLand
{
    public class Metronome : MonoBehaviour
    {
        public AudioSource audioSource;
        public double bpm = 90f;
    
        double nextTick = 0.0F; // The next tick in dspTime
        double sampleRate = 0.0F; 
        bool ticked = false;
        bool isMetronomeOn;
    
        void Start() {
            ResetTick();
            isMetronomeOn = false;
        }
    
        void LateUpdate() {
            if (isMetronomeOn)
            {
                if ( !ticked && nextTick >= AudioSettings.dspTime ) {
                    ticked = true;
                    OnTick();
                    //BroadcastMessage( "OnTick" );
                }
            }
        }
    
        // Just an example OnTick here
        void OnTick() {
            //Debug.Log( "Tick" );
            audioSource.Play();
            // GetComponent<AudioSource>().Play();
        }
    
        void FixedUpdate() {
            var timePerTick = 60.0f / bpm;
            var dspTime = AudioSettings.dspTime;
    
            while ( dspTime >= nextTick ) {
                ticked = false;
                nextTick += timePerTick;
            }
        }

        private void ResetTick()
        {
            var startTick = AudioSettings.dspTime;
            //sampleRate = AudioSettings.outputSampleRate;
    
            nextTick = startTick + (60.0 / bpm);
        }
        
        public void SetMetronomeOn(bool isOn)
        {
            isMetronomeOn = isOn;
            if (isOn)
            {
                ResetTick();
            }
        }
    
        public void ToggleMetronome()
        {
            isMetronomeOn = !isMetronomeOn;
        }
    }

}
