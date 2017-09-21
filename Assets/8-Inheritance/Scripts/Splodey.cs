﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float explosionRadius = 5f;
        public float knockback = 100f;

        protected override void Attack()
        {
            // Play an animation
            // Perform explosion physics
            Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (var hit in hits)
            {
                Health h = hit.gameObject.GetComponent<Health>();
                if (h != null)
                {
                    h.TakeDamage(damage);
                }
                Rigidbody r = hit.gameObject.GetComponent<Rigidbody>();
                if (r != null)
                {
                    r.AddExplosionForce(knockback, transform.position, explosionRadius, 0f, ForceMode.Impulse);
                }
            }
        }
        protected override void OnAttackEnd()
        {
            Destroy(gameObject);
        }
    }
}