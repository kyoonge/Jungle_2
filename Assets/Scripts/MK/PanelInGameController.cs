using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInGameController : MonoBehaviour
{
    private Slider hpBar;
    private Image fill;
    [SerializeField]private float decreaseHpAmount = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = transform.Find("HPBar").gameObject.GetComponent<Slider>();
        fill = transform.Find("HPBar/Fill Area/Fill").gameObject.GetComponent<Image>();
        hpBar.value = 1f;
    }

    //HP 줄어들기 시작 함수_ 카운트 다운 후 실행
    public void  startHP()
    {
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
            hpBar.value -= 0.03f; // 감소량을 조절하려면 원하는 값으로 변경
            // value가 최소값에 도달하면 종료
            if (hpBar.value <= 0)
            {
                hpBar.value = 0;
                yield break; // 코루틴 종료
            }
            else if(0<hpBar.value && hpBar.value <= 0.3)
            {
                fill.color = Color.red;
            }
            else if(0.3<=hpBar.value && hpBar.value <= 0.5)
            {
                fill.color = Color.yellow;
            }
            yield return new WaitForSeconds(2f); // 3초 대기
        }
    }

}
