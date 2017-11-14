using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone
{
    [RequireComponent(typeof(BoxCollider))]
    public class Enemy : MonoBehaviour
    {
        public float movementSpeed = 5f;
        public float rayDistance = 1.1f;
        public bool isMovingLeft = true;

        private Ray leftRay;
        private Ray rightRay;
        private BoxCollider box;

        private void Awake()
        {
            box = GetComponent<BoxCollider>();
        }

        private void OnDrawGizmos()
        {
            box = GetComponent<BoxCollider>();
            RecalculateRays();
            Gizmos.color = Color.red;
            Gizmos.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * rayDistance);
            Gizmos.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * rayDistance);
        }

        void RecalculateRays()
        {
            Vector3 halfSize = box.bounds.size * 0.5f;
            Vector3 leftPos = transform.position - Vector3.left * halfSize.x;
            Vector3 rightPos = transform.position - Vector3.right * halfSize.x;
            leftRay = new Ray(leftPos, Vector3.down);
            rightRay = new Ray(rightPos, Vector3.down);
        }

        public void Move()
        {
            RecalculateRays();

            Vector3 pos = transform.position;

            // Perform raycast check
            bool isLeftHitting = Physics.Raycast(leftRay, rayDistance);
            bool isRightHitting = Physics.Raycast(rightRay, rayDistance);

            if (isLeftHitting && !isRightHitting)
                isMovingLeft = false;
            else if (isRightHitting && !isLeftHitting)
                isMovingLeft = true;

            Vector3 dir = Vector3.zero;
            if (isMovingLeft)
                dir += Vector3.left;
            else
                dir += Vector3.right;

            pos += dir * movementSpeed * Time.deltaTime;
            transform.position = pos;
        }
        public virtual void Update()
        {
            Move();
        }
        public virtual void Damage(int combo = 0)
        {

        }
    }
}