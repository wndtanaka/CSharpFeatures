using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject[] asteroidsPrefabs;
        public float spawnRate = 1f;
        public float spawnRadius = 5f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        void Spawn()
        {
            Vector3 rand = Random.insideUnitSphere * spawnRadius;
            rand.z  = 0f;
            Vector3 pos = rand + transform.position;
            int index = Random.Range(0, asteroidsPrefabs.Length);
            GameObject clone = Instantiate(asteroidsPrefabs[index]);
            clone.transform.position = pos;
        }

        // Use this for initialization
        void Start()
        {
            InvokeRepeating("Spawn", 0f, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}