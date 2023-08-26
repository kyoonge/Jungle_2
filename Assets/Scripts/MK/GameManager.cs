using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { Init(); return _instance; } }

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

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
