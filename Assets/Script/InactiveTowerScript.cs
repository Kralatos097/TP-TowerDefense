using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveTowerScript : MonoBehaviour
{
    [Header("Values")]
    public int towerRange;
    
    [Header("Drag&Drop")]
    public SphereCollider Range;
    public MeshRenderer graphMat;

    public Material inactMat;
    public Material overMat;
    public Material actMat;

    private int _buyCost = MoneyScript.MonneyPTower;

    private void OnMouseEnter()
    {
        graphMat.material = overMat;
    }

    private void OnMouseExit()
    {
        graphMat.material = inactMat;
    }

    private void OnMouseDown()
    {
        if (MoneyScript.LooseMonney(_buyCost))
        {
            gameObject.GetComponent<TowerScript>().isActive = true;

            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        graphMat.material = actMat;
    }
}
