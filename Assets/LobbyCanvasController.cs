using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCanvasController : MonoBehaviour
{
    public void LoadScene(int SceneIndex)
    {
        GameManager.Instance.LoadScene(SceneIndex);
    }
}
