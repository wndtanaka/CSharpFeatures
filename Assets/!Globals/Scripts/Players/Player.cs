using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 50f;

    Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        float camY = Camera.main.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, camY, 0);

        Vector3 inputDir = rotation * new Vector3(inputH, 0f, inputV);
        rb.AddForce(inputDir * movementSpeed);
    }
}