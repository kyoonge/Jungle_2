using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaticsUI : MonoBehaviour
{
    public TMP_Text perfectText;
    public TMP_Text normalText;
    public TMP_Text missText;
    public TMP_Text maxComboText;
    
    StaticsManager staticsManager;
    
    void Awake()
    {
        staticsManager = FindObjectOfType<StaticsManager>();
    }
    
    public void InitStaticsUI()
    {
        perfectText.text = ": " + staticsManager.PerfectCounter;
        normalText.text = ": " + staticsManager.NormalCounter;
        missText.text = ": " + staticsManager.MissCounter;
        maxComboText.text = ": " + staticsManager.MaxCombo;
    }
}
