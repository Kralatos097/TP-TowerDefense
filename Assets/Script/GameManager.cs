using System.Collections;
using System.Collections.Generic;
using TMPro;
using TPTowerDefense;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float targetTime = 60;

    public TextMeshProUGUI timerUI;

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        
        if (targetTime <= 0.0f)
        {
            TimerEnded();
        }
        else
        {
            timerUI.text = ((int)targetTime).ToString();
        }
    }

    private void TimerEnded()
    {
        Debug.Log("Timer Ended !");

        foreach (EnnemyScript ennemy in EnnemyScript.EnnemyList)
        {
            Destroy(ennemy.gameObject);
        }
        
    }

}
