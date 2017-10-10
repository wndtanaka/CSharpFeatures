using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float health = 100f;
    public float movementSpeed = 50f;

    Rigidbody rb;
    
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector3 movementDir = new Vector3(inputH,0,inputV);
        rb.AddForce(movementDir * movementSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
