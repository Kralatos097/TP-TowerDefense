using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    //public TextMeshProUGUI PVUI;

    public MeshRenderer mat;

    public static List<BaseScript> Bases;

    public int _PV = 5;
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
            mat.material.color = new Color(1, ((float)_PV / _MaxPV), 0);
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

    private void Awake()
    {
        if (Bases == null)
        {
            Bases = new List<BaseScript>();
        }
        Bases.Add(this);
    }

    private void Start()
    {
        _MaxPV = _PV;

        mat.material.color = Color.green;
    }

    private void Defeat()
    {
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            PV--;
        }
    }

    private void OnDestroy()
    {
        Bases.Remove(this);
    }
}
