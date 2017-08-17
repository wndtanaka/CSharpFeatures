using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Collisions
{
    public class PlayerShip : MonoBehaviour
    {
        public float acceleration = 20f;
        public float rotationSpeed = 360f;
        public float hyperSpeed = 150f;

        private Rigidbody2D rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Accelerate();
            Rotate();
        }
        void Accelerate()
        {
            float inputV = Input.GetAxis("Vertical");
            float currentSpeed = acceleration;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = hyperSpeed;
            }
            rigid.AddForce(transform.up * inputV * currentSpeed);


        }
        void Rotate()
        {
            float inputH = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.back, rotationSpeed * inputH * Time.deltaTime);
        }
    }
}