using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyScript : MonoBehaviour
{
    public int monneyPeBaseValue;
    public int monneyPtBaseValue;
    public static int MonneyPEnnemy = 3;
    public static int MonneyPTower = 5;
    
    public int towerFireRateBonusBaseValue;
    public int towerFireRangeBonusBaseValue;
    public static int TowerFireRateBonus;
    public static int TowerFireRangeBonus;
    

    public int startMonney;
    private static int _currentMonney;
    public static int Monney
    {
        get => _currentMonney;

        private set
        {
            _currentMonney = value;
        }
    }
    
    public TextMeshProUGUI monneyDisplay;
    private static TextMeshProUGUI _monneyDisplay;
    
    

    private void Awake()
    {
        Monney = startMonney;
        TowerFireRateBonus = towerFireRateBonusBaseValue;
        TowerFireRangeBonus = towerFireRangeBonusBaseValue;
        
        _monneyDisplay = monneyDisplay;
    }

    public static void GainMonney(int gain)
    {
        Monney += gain;
        _monneyDisplay.text = _currentMonney.ToString();
    }

    public static bool LooseMonney(int cost)
    {
        if(Monney >= cost)
        {
            Monney -= cost;
            _monneyDisplay.text = _currentMonney.ToString();
            return true;
        }

        return false;
    }
}
