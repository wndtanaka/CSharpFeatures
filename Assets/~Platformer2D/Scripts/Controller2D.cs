using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller2D : MonoBehaviour
    {
        public float accelerate = 20f;
        public float jumpHeight = 10f;
        public float rayDistance = 1f;
        public LayerMask hitLayer;
        public bool isGrounded = false;

        private Rigidbody2D rigid2d;
        // Use this for initialization
        void Awake()
        {
            rigid2d = GetComponent<Rigidbody2D>();
        }
        // Handles Movement
        public void Move(float inputH)
        {
            rigid2d.AddForce(transform.right * inputH * accelerate);
        }

        // Allows for jump when called
        public void Jump()
        {
            rigid2d.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, rayDistance, hitLayer);
            if (hit.collider != null)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + -transform.up * rayDistance);
        }
    }
}