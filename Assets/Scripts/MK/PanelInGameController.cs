using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInGameController : MonoBehaviour
{
    public Slider hpBar;
    private Image fill;
    [SerializeField]private float decreaseHpAmount = 0.02f;
    [SerializeField] private float decreaseHpDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        fill = hpBar.transform.Find("Fill Area/Fill").gameObject.GetComponent<Image>();
        
    }

    //HP 줄어들기 시작 함수_ 카운트 다운 후 실행
    public void startHP()
    {
        hpBar.value = 1;
        StartCoroutine("DecreaseHPBarCoroutine");
    }

    public void increaseHP(float value)
    {
        hpBar.value += value; 
    }

    private IEnumerator DecreaseHPBarCoroutine()
    {
        while (true)
        {
            // 현재 HPBar의 value 값을 줄이기
            hpBar.value -= decreaseHpAmount; 
            // value가 최소값에 도달하면 종료
            if (hpBar.value <= 0)
            {
                hpBar.value = 0;
                UIManager.instance.GameOver();
                yield break; // 코루틴 종료
            }
            else if(0<hpBar.value && hpBar.value <= 0.25)
            {
                fill.color = Color.red;
            }
            else if(0.3<=hpBar.value && hpBar.value <= 0.5)
            {
                fill.color = Color.yellow;
            }
            yield return new WaitForSeconds(decreaseHpDelay); // 2초 대기
        }
    }

}
