using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;


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
        private bool IsDead
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

        public Transform objectif;
        
        public static List<EnnemyScript> EnnemyList;

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
            objectif = GameObject.FindWithTag("Base").transform;
            deplacement();
        }
        
        private void OnDestroy()
        {
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