using System;
using System.Collections;
using System.Collections.Generic;
using onLand;
using UnityEngine;

public class InclineManager : MonoBehaviour
{
    public GameObject keyEffects;
    public GameObject sheet;

    public float degree;

    private void Start()
    {
        var newRot = new Vector3(degree, 0f, 0f);
        
        for (int i = 0; i < 7; i++)
        {
            var effectKey = keyEffects.transform.GetChild(i).gameObject;
            effectKey.transform.rotation = Quaternion.Euler(newRot);
        }
        sheet.transform.rotation = Quaternion.Euler(newRot);
        var movingPlate = sheet.transform.Find("MovingPlate").gameObject;
        movingPlate.GetComponent<MovingPlate>().originPosition = movingPlate.transform.position;
    }
}
