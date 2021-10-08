using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float laserTime;
    
    void Awake()
    {
        Invoke("Death", laserTime);
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
