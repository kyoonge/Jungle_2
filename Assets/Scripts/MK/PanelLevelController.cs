/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLevelController : MonoBehaviour
{
    private GameObject easyLevel, hardLevel;
    private Button btn_easyLevel, btn_hardLevel;

    // Start is called before the first frame update
    void Start()
    {
        easyLevel = transform.Find("Button_Easy").gameObject;
        hardLevel = transform.Find("Button_Hard").gameObject;

        btn_easyLevel = easyLevel.GetComponent<Button>();
        btn_hardLevel = hardLevel.GetComponent<Button>();

        btn_easyLevel.onClick.AddListener(() => SelectLevel("Easy"));
        btn_hardLevel.onClick.AddListener(() => SelectLevel("Hard"));

    }
    private void SelectLevel(string level)
    {
        Debug.Log(level);
        if (level.Equals("Easy"))
        {
            GameManager.Instance.level = 0;
        }
        else
        {
            GameManager.Instance.level = 1;
        }
        this.gameObject.SetActive(false);
    }
}
*/