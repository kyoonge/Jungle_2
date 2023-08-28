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

    //HP �پ��� ���� �Լ�_ ī��Ʈ �ٿ� �� ����
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
            // ���� HPBar�� value ���� ���̱�
            hpBar.value -= decreaseHpAmount; 
            // value�� �ּҰ��� �����ϸ� ����
            if (hpBar.value <= 0)
            {
                hpBar.value = 0;
                UIManager.instance.GameOver();
                yield break; // �ڷ�ƾ ����
            }
            else if(0<hpBar.value && hpBar.value <= 0.25)
            {
                fill.color = Color.red;
            }
            else if(0.3<=hpBar.value && hpBar.value <= 0.5)
            {
                fill.color = Color.yellow;
            }
            yield return new WaitForSeconds(decreaseHpDelay); // 2�� ���
        }
    }

}
