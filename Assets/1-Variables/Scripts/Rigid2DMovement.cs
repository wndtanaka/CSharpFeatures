using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigid2DMovement : MonoBehaviour
{
    /*public float movementSpeed = 70f;
    public float rotationSpeed = 120f;
    public float decelaration = 10f;*/
    public float rotationSpeed = 5f;
    public float acceleration = 30f;
    public float deceleration = 0.1f;

    private Rigidbody2D rigid2D;

    // Use this for initialization
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Movement();
        Decelarate();
        Rotation();*/
        // if user presses 'W'
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rigid2D.AddForce(transform.right * acceleration);
        }
        // if user presses 'S'
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rigid2D.AddForce(-transform.right * acceleration);
        }
        // if user presses 'S'
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, rotationSpeed);
        }
        // if user presses 'S'
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward, rotationSpeed);
        }
        // decelarating
        rigid2D.velocity += -rigid2D.velocity * deceleration;
    }

   /* void Movement()
    {
        float inputV = Input.GetAxis("Vertical");
        rigid2D2D.AddForce(transform.up * inputV * movementSpeed);
    }

    void Rotation()
    {
        float inputH = Input.GetAxis("Horizontal");
        {
            transform.rotation *= Quaternion.AngleAxis(inputH * rotationSpeed * Time.deltaTime, Vector3.back);
        }
    }

    void Decelarate()
    {
        rigid2D2D.velocity += -rigid2D2D.velocity * decelaration * Time.deltaTime;
    }*/
}
