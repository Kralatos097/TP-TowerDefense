using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TPTowerDefense;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    public float fireRate;
    private float _count;
    private static float _fireRateBonus;
    public float fireRateGain;
    
    public float fireRange;
    private static float _fireRangeBonus;
    public float fireRangeGain;

    public bool isActive = false;

    public GameObject laserPrefab;
    private static Button _fireRateBonusButton;
    private static Button _fireRangeBonusButton;

    private EnnemyScript target;

    // Start is called before the first frame update
    void Start()
    {
        _fireRangeBonusButton = GameObject.Find("FireRangeBonusButton").GetComponent<Button>();
        _fireRateBonusButton = GameObject.Find("FireRateBonusButton").GetComponent<Button>();
        
        _count = fireRate;

        _fireRangeBonus = fireRange;
        _fireRateBonus = fireRate;
    }

    private void Update()
    {
        if (isActive)
        {
            if (target == null)
            {
                target = changeTarget();
            }
            else if (Vector3.Distance(target.transform.position, this.transform.position) >= _fireRangeBonus)
            {
                target = changeTarget();
            }
            else
            {
                _count -= Time.deltaTime;
                if (_count <= 0)
                {
                    Fire();
                    _count = _fireRateBonus;
                }
            }
        }
    }

    public EnnemyScript changeTarget()
    {
        if(EnnemyScript.EnnemyList == null)
        {
            return null;
        }
        foreach (EnnemyScript ennemy in EnnemyScript.EnnemyList)
        {
            if (Vector3.Distance(ennemy.transform.position, this.transform.position) <= _fireRangeBonus)
            {
                return ennemy;
            }
        }

        return null;
    }

    //Modifier pour passer par la List d'ennemies de EnnemyScript et calculer via distance et non via collider
    public void Fire()
    {
        GameObject laser = Instantiate(laserPrefab);
        laser.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        laser.GetComponent<LineRenderer>().SetPosition(1, target.transform.position);

        target.PV--;

        if(target.IsDead)
        {
            MoneyScript.GainMonney(MoneyScript.MonneyPEnnemy);
            target = null;
        }
    }

    public void FireRateBonus()
    {
        if (MoneyScript.LooseMonney(MoneyScript.TowerFireRateBonus))
        {
            MoneyScript.TowerFireRateBonus *= 2;
            _fireRateBonus /= fireRateGain;
        }
        if(_fireRateBonus <= fireRate/4)
        {
            _fireRateBonusButton.interactable = false;
            GameObject.Find("FireRateBonusPrice").GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
    
    public void FireRangeBonus()
    {
        if (MoneyScript.LooseMonney(MoneyScript.TowerFireRangeBonus))
        {
            MoneyScript.TowerFireRangeBonus *= 2;
            _fireRangeBonus *= fireRangeGain;
        }
        if(_fireRangeBonus >= fireRange*1.75)
        {
            _fireRangeBonusButton.interactable = false;
            GameObject.Find("FireRangeBonusPrice").GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, _fireRangeBonus);
    }*/
}
