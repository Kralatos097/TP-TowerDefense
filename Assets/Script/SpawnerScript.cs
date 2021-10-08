using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnnemyPrefab;

    public int SpawnTime;
    public int SpawnFreq;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnnemy", SpawnTime, SpawnFreq);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnnemy()
    {
        Instantiate(EnnemyPrefab,transform.position, Quaternion.identity);
    }
}
