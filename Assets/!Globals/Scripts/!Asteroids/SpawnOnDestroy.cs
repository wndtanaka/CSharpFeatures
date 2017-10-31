using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    public GameObject partPrefab;

    GameObject particle;
    Animator anim;

    void Awake()
    {
        anim = partPrefab.GetComponent<Animator>();
    }
    void OnDestroy()
    {
        GameObject particle = Instantiate(partPrefab, transform.position, transform.rotation);
        Destroy(particle, 0.5f);
    }
}
