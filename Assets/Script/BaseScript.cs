using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public TextMeshProUGUI PVUI;

    public Material mat;

    private int _PV = 5;
    private int _MaxPV;
    public int PV
    {
        get => _PV;

        set
        {
            _PV = value;
            if (_PV <= 0)
            {
                _PV = 0;
                IsDead = true;
            }
            mat.color = new Color(1, ((float)_PV / _MaxPV), 0);
            PVUI.text = _PV + " / " + _MaxPV;
        }
    }
    
    private bool _isDead = false;
    private bool IsDead
    {
        get => _isDead;

        set
        {
            _isDead = value;
            if (_isDead)
            {
                Defeat();
            }
        }
    }

    private void Start()
    {
        _MaxPV = _PV;
        PVUI.text = _PV + " / " + _MaxPV;

        mat.color = Color.green;
    }

    private void Defeat()
    {
        Debug.Log("Defeat");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            PV--;
        }
    }
}
