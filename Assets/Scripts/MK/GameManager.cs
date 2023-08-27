using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { Init(); return _instance; } }
    //private readonly UIManager _ui = new UIManager();
    //public static UIManager UI => _instance._ui;

    public bool isRestart;
    public int level; // Easy=0, Hard=1

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            if (go == null)
            {
                go = new GameObject { name = "GameManager" };
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<GameManager>();
            
            //ui매니저 초기화
            //_instance._ui.Init();
        }
        
        //Stage씬은 3초 카운트다운으로 시작
        if(SceneManager.GetActiveScene().buildIndex >= 2 && SceneManager.GetActiveScene().buildIndex <=4)
        {
            UIManager.instance.CountDown();
            //UI.CountDown();
            //CountDown();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isRestart = false;

        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isRestart)
        {
            //게임종료
            Debug.Log("Restart");
            ReloadScene();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("StageLoby");
    }

    public void TutorialStage()
    {
        SceneManager.LoadScene("Stage");
    }

    public void StartStageEasy()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void StartStageHard()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        AkSoundEngine.PostEvent("GameOver", gameObject);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
