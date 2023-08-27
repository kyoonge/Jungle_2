using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleManager : MonoBehaviour
{
    public static RumbleManager instance;
    
    private Gamepad gamepad;

    private Coroutine stopRumbleAfterTimeCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void RumblePulse(float lowFreq, float highFreq, float duration)
    {
        gamepad = Gamepad.current;

        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(lowFreq, highFreq);
            stopRumbleAfterTimeCoroutine = StartCoroutine(StopRumble(duration, gamepad));
        }
    }
    
    private IEnumerator StopRumble(float duration, Gamepad gamepad)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gamepad.SetMotorSpeeds(0, 0);
    }
}
