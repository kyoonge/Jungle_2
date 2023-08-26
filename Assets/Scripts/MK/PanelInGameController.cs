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

    //HP �پ��� ���� �Լ�_ ī��Ʈ �ٿ� �� ����
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
            // ���� HPBar�� value ���� ���̱�
            hpBar.value -= 0.03f; // ���ҷ��� �����Ϸ��� ���ϴ� ������ ����
            // value�� �ּҰ��� �����ϸ� ����
            if (hpBar.value <= 0)
            {
                hpBar.value = 0;
                yield break; // �ڷ�ƾ ����
            }
            else if(0<hpBar.value && hpBar.value <= 0.3)
            {
                fill.color = Color.red;
            }
            else if(0.3<=hpBar.value && hpBar.value <= 0.5)
            {
                fill.color = Color.yellow;
            }
            yield return new WaitForSeconds(2f); // 3�� ���
        }
    }

}
