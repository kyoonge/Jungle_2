using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticsManager : MonoBehaviour
{
    public int PerfectCounter { get; private set; }
    public int NormalCounter { get; private set; }
    public int MissCounter { get; private set; }
    public int ComboCounter { get; private set; }
    public int MaxCombo { get; private set; }
    
    void Awake()
    {
        Reset();
    }

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        PerfectCounter = 0;
        NormalCounter = 0;
        MissCounter = 0;
        ComboCounter = 0;
        MaxCombo = 0;
    }
    
    public void AddPerfect()
    {
        PerfectCounter++;
        ComboCounter++;
        if (ComboCounter > MaxCombo)
            MaxCombo = ComboCounter;
    }
    
    public void AddNormal()
    {
        NormalCounter++;
        ComboCounter++;
        if (ComboCounter > MaxCombo)
            MaxCombo = ComboCounter;
    }
    
    public void AddMiss()
    {
        MissCounter++;
        ComboCounter = 0;
    }
    
    
}
