﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float respawnTime = 3f;

    private Vector3 spawnPos;
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    // Use this for initialization
    void Start()
    {
        spawnPos = transform.position;
    }

    public void Spawn()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        rend.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        transform.position = spawnPos;
        rend.enabled = true;
    }
}
