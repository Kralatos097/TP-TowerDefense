using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TPTowerDefense;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float targetTime = 60;

    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI fireRateBonusCostUI;
    public TextMeshProUGUI fireRangeBonusCostUI;

    public GameObject VictoryPannel;
    public GameObject DefeatPannel;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (BaseScript.Bases.Count <= 0)
        {
            Defeat();
        }
        
        if (targetTime <= 0.0f)
        {
            TimerEnded();
        }
        else
        {
            timerUI.text = ((int)targetTime).ToString();
        }

        fireRangeBonusCostUI.text = MoneyScript.TowerFireRangeBonus.ToString();
        fireRateBonusCostUI.text = MoneyScript.TowerFireRateBonus.ToString();
    }

    private void TimerEnded()
    {
        foreach (EnnemyScript ennemy in EnnemyScript.EnnemyList)
        {
            Destroy(ennemy.gameObject);
        }

        Time.timeScale = 0;
        VictoryPannel.SetActive(true);
    }

    private void Defeat()
    {
        Debug.Log("Defeat !");
        Time.timeScale = 0;
        DefeatPannel.SetActive(true);
    }
}
