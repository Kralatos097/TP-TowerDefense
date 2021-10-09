using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnnemyPrefab;

    public int spawnTime;
    public float spawnFreq;
    public float spawnFreqMin;
    [Range(0,1)]
    public float spawnFreqReduc;

    private float _count;
    
    // Start is called before the first frame update
    void Start()
    {
        _count = spawnTime;
        //InvokeRepeating("SpawnEnnemy", SpawnTime, SpawnFreq);
    }

    // Update is called once per frame
    void Update()
    {
        _count -= Time.deltaTime;
        if (_count <= 0)
        {
            SpawnEnnemy();
            _count = spawnFreq;
            if(spawnFreq >= spawnFreqMin)
            {
                spawnFreq *= spawnFreqReduc;
            }
            
        }
    }

    private void SpawnEnnemy()
    {
        Instantiate(EnnemyPrefab,transform.position, Quaternion.identity);
    }
}
