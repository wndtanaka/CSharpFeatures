﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class AIAgentSpawner : MonoBehaviour
    {
        public GameObject aiAgentPrefab; // Prefab of AI Agent
        public Transform target; // Target that each AI agent should travel to
        public float spawnRate = 1f; // Rate of spawn
        public float spawnRadius = 1f; // Radius of spawn


        // Use this for initialization
        void Start()
        {
            // InvokeRepeating(functionName, time, repeatRate)
            // functionName = name of the function you want to call in the class
            // time         = delay for when the function gets called the firs time
            // repeatRate   = how often the function gets called
            InvokeRepeating("Spawn", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {

        }
        // Visualization code
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            // Draw a sphere to indicate the spawn radius
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        void Spawn()
        {
            // LET clone = new instance of aiAgentPrefab
            GameObject clone = Instantiate(aiAgentPrefab);
            // LET rand = Random Inside Unit Sphere
            Vector3 rand = Random.insideUnitSphere;
            // SET rand.y = 0;
            rand.y = 0;
            // SET clone's position to transform's position + rand * spawnRadius
            clone.transform.position = transform.position + rand * spawnRadius;
            // SET aiAgent = clone's AIAgent component
            AIAgent aiAgent = clone.GetComponent<AIAgent>();
            // SET aiAgent.target = target
            aiAgent.target = target;
        }
    }
}