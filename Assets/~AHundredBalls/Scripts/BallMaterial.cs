using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaterial : MonoBehaviour
{
    public Material[] mat;

    Renderer rend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int randomIndex = Random.Range(0, mat.Length);
    }
}
