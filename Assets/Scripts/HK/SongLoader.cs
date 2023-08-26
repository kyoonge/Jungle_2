using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SongLoader : MonoBehaviour
{
    private StageManager _stageManager;
    private const string TestStage_Easy = "TestStage_Easy";

    private void Awake()
    {
        _stageManager = FindObjectOfType<StageManager>();
    }

    public void StageSelect()
    {
        
        SceneManager.LoadScene("1_Scene/Stage");
        SetStageData();
    }

    public void SetStageData()
    {
       string ButtonName = EventSystem.current.currentSelectedGameObject.name;

        if(ButtonName == TestStage_Easy)
        {
            _stageManager.PlayStage1();
        }

    }
}
