using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Ball : MonoBehaviour
    {

        public float speed = 10f; // speed for the ball

        private Vector3 velocity; // speed x direction

        // Update is called once per frame
        void Update()
        {
            // moving ball using velocity & deltatime
            transform.position += velocity * Time.deltaTime;
        }
        // detect collision
        void OnCollisionEnter2D(Collision2D other)
        {
            // grab contact point of collisions
            ContactPoint2D contact = other.contacts[0];
            // calculate the reflection of the ball using velocity and contact normal
            Vector3 reflect = Vector3.Reflect(velocity,contact.normal);
            // calculate new velocity  from reflection multiply by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
        }
        // send the balls flying in a given direction
        public void Fire(Vector3 direction)
        {
            velocity = direction * speed;
        }

    }
}