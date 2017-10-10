using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform target;
    public float spawnRate = 3f;
    public float spawnRadius = 1f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
    void Spawn()
    {

        GameObject clone = Instantiate(enemyPrefab);
        Vector3 rand = Random.insideUnitSphere;
        rand.y = 0;
        clone.transform.position = transform.position + rand * spawnRadius;
        EnemyAgent aiAgent = clone.GetComponent<EnemyAgent>();
        aiAgent.target = target;
    }
}
