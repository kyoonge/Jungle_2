using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public PanelInGameController panelIngameController;
    public TextMeshProUGUI txtCount;
    public GameObject Panel_GameOver, Panel_GameClear;
    

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
        panelIngameController.gameObject.SetActive(false);
        txtCount.gameObject.SetActive(true);
        Panel_GameOver.SetActive(false);
        Panel_GameClear.SetActive(false);
        CountDown();

    }


    public void PopupSetting()
    {

    }

    public void CountDown()
    {
        StartCoroutine("CountdownCoroutine");
    }

    private IEnumerator CountdownCoroutine()
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
        panelIngameController.gameObject.SetActive(true);
        panelIngameController.startHP();
        StageMusic();
        
    }

    public void StageMusic()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 3 && SceneManager.GetActiveScene().buildIndex <= 5)
        {
            AkSoundEngine.PostEvent("MainSong", gameObject);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            AkSoundEngine.PostEvent("TestSong", gameObject);
        }
        else
        {
            //
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        panelIngameController.gameObject.SetActive(false);
        AkSoundEngine.PostEvent("FadeOut", gameObject);
        Panel_GameOver.gameObject.SetActive(true);
    }

    public void GameClear()
    {
        Time.timeScale = 0;
        panelIngameController.gameObject.SetActive(false);
        Panel_GameClear.gameObject.SetActive(true);
    }
    public void ReStartScene()
    {
        GameManager.Instance.ReloadScene();
    }

    public void GoLobyScene()
    {
        GameManager.Instance.LobyScene();
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
