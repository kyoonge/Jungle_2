using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public PanelInGameController panelIngameController;
    public TextMeshProUGUI txtCount;

    // Start is called before the first frame update
    public void Init()
    {
        //panelLevelController.GetComponent<PanelLevelController>();
        //txtCount = transform.Find("Text_Count").gameObject.GetComponent<TextMeshProUGUI>();

    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //panelIngameController = transform.GetComponent<PanelInGameController>();
    }


    public void PopupSetting()
    {
        
    }

    public void CountDown()
    {
        StartCoroutine("CountdownCoroutine");
    }

    public IEnumerator CountdownCoroutine()
    {
        int countdownTime = 3;
        Time.timeScale = 0; // Stop time
        while (countdownTime > 0)
        {
            txtCount.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
            AkSoundEngine.PostEvent("Count", gameObject);
        }

        txtCount.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);
        txtCount.gameObject.SetActive(false);
        Time.timeScale = 1;

        
        //start HP system
        panelIngameController.startHP();
    }

}
