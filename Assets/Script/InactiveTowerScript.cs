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

    private void OnMouseOver()
    {
        graphMat.material = overMat;
    }

    private void OnMouseExit()
    {
        graphMat.material = inactMat;
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<TowerScript>().enabled = true;
        Range.radius = towerRange;

        Destroy(this);
    }

    private void OnDestroy()
    {
        graphMat.material = actMat;
    }
}
