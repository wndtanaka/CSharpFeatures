using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class Ball : MonoBehaviour
    {
        public float stopSpeed = 0.2f;

        private Rigidbody rb;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 vel = rb.velocity;

            // Check if the velocity is going up
            if (vel.y >0)
            {
                // cap velocity
                vel.y = 0;
            }
            // If the velocity's speed is less then stop speed, then stop
            if (vel.magnitude < stopSpeed)
            {
                vel = Vector3.zero;
            }
            rb.velocity = vel;
        }
        public void Hit(Vector3 dir, float impactForce)
        {
            rb.AddForce(dir * impactForce, ForceMode.Impulse);
        }
    }
}