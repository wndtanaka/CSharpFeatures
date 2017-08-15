using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopsArrays
{
    public class Loops : MonoBehaviour
    {
        public GameObject[] spawnPrefab;
        public float frequency = 3f;
        public float amplitude = 6f;
        public float spawnRadius = 5f;
        public string message = "Print This";
        public float printTime = 2f;
        public int spawnAmount = 10;

        private float timer = 0f;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            SpawnObjectsWithSine();
        }

        // Update is called once per frame
        void Update()
        {

            while (timer <= printTime)
            {
                timer += Time.deltaTime;
                print("PUT THE COOKIE DOWN");

            }
        }
        void SpawnObjectsWithSine()
        {
            /*
            for (initialization, condition, iteration)
            {
                Statment
            }
            */
            for (int i = 0; i < spawnAmount; i++)
            {
                int randomIndex = Random.Range(0, spawnPrefab.Length);
                GameObject randomPrefab = Instantiate(spawnPrefab[randomIndex]);
                GameObject clone = randomPrefab;
                // Generated random position between circle (sphere actually)
                MeshRenderer rend = clone.GetComponent<MeshRenderer>();
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                float a = 1;
                rend.material.color = new Color(r, g, b, a);

                float x = Mathf.Sin(i * frequency) * amplitude;
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                Vector3 randomPos = transform.position + new Vector3(x, y, z);
                // cancel out the X
                // randomPos.z = 0;
                // set spawned object's position
                clone.transform.position = randomPos;

            }
        }
        void SpawnObjects()
        {
            /*
            for (initialization, condition, iteration)
            {
                Statment
            }
            */
            for (int i = 0; i < spawnAmount; i++)
            {
                /*GameObject clone = Instantiate(spawnPrefab);
                // Generated random position between circle (sphere actually)
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                // cancel out the X
                randomPos.z = 0;
                // set spawned object's position
                clone.transform.position = randomPos;
                */
            }
        }
    }
}

