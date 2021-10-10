using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace TPTowerDefense
{
    public class EnnemyScript : MonoBehaviour
    {
        private int _PV = 2;
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
            }
        }

        private bool _isDead = false;
        public bool IsDead
        {
            get => _isDead;

            set
            {
                _isDead = value;
                if (_isDead)
                {
                    
                    Destroy(gameObject);
                }
            }
        }

        //private NavMeshPath path;

        public Transform objectif;

        public static List<EnnemyScript> EnnemyList;
        
        public AudioClip clip;

        void Awake()
        {
            if(EnnemyList == null)
            {
                EnnemyList = new List<EnnemyScript>();
            }
            EnnemyList.Add(this);
        }

        private void Start()
        {
            //objectif = GameObject.FindWithTag("Base").transform;
            /*path = new NavMeshPath();
            float distOE = 10000;
            float dist;
            foreach (BaseScript b in BaseScript.Bases)
            {
                bool a = NavMesh.CalculatePath(transform.position, b.transform.position, NavMesh.AllAreas, path);
                Debug.Log("hhhhhhhhh "+a);
                if(a)
                {
                    Transform objectifTemp = b.transform;
                    GetComponent<NavMeshAgent>().destination = objectifTemp.position;
                    dist = GetComponent<NavMeshAgent>().remainingDistance;
                    
                    if (dist < distOE)
                    {
                        
                        distOE = dist;
                        objectif = objectifTemp;
                    }
                }
            }*/

            /*if (objectif == null)
            {
                objectif = BaseScript.Bases[0].transform;
            }*/
            int index = Random.Range(0,BaseScript.Bases.Count);
            objectif = BaseScript.Bases[index].transform;
        }

        private void Update()
        {
            deplacement();
        }

        private void OnDestroy()
        {
            AudioSource.PlayClipAtPoint(clip, transform.position, 5);
            EnnemyList.Remove(this);
        }

        public void deplacement()
        {
            gameObject.GetComponent<NavMeshAgent>().destination = objectif.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Base"))
            {
                IsDead = true;
            }
        }
    }
}