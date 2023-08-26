using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeModifier : MonoBehaviour
{
    [SerializeField] private Text timeScaleText;
    
    float[] timeScales = { 0.1f, 0.25f, 0.5f, 1f, 2f};
    int timeScaleIndex = 3;

    private void Awake()
    {
        if (timeScaleText == null)
        {
            timeScaleText = GetComponent<Text>();
        }
        
        timeScaleText.text = "Time Scale: " + timeScales[timeScaleIndex];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
           OnTimeModifierButtonClicked(); 
        }
    }

    public void OnTimeModifierButtonClicked()
    {
        timeScaleIndex++;
        if (timeScaleIndex >= timeScales.Length)
        {
            timeScaleIndex = 0;
        }
        timeScaleText.text = "Time Scale: " + timeScales[timeScaleIndex];
        Time.timeScale = timeScales[timeScaleIndex];    
    }
}
