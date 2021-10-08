using System;
using System.Collections;
using System.Collections.Generic;
using TPTowerDefense;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public float fireRate;

    public GameObject laserPrefab;
    
    private List<GameObject> inRangeEnnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0, fireRate);
    }

    public void Fire()
    {
        if (inRangeEnnemies.Count != 0)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.GetComponent<LineRenderer>().SetPosition(0, transform.position);
            laser.GetComponent<LineRenderer>().SetPosition(1, inRangeEnnemies[0].transform.position);
            
            inRangeEnnemies[0].GetComponent<EnnemyScript>().PV--;
            if (inRangeEnnemies[0].GetComponent<EnnemyScript>()._isDead)
            {
                inRangeEnnemies.Remove(inRangeEnnemies[0]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            inRangeEnnemies.Add(other.gameObject);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            inRangeEnnemies.Remove(other.gameObject);
        }
    }
}
