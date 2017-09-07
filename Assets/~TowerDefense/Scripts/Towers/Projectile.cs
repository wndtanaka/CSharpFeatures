using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Projectile : MonoBehaviour
    {
        public float damage = 50f; // Damage delat to whatever gets hit
        public float speed = 50f; // Speed the projectile travels
        public Vector3 direction; // Direction the projectile travels

        Enemy e;
        Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            rb.velocity = direction.normalized * speed;
            transform.position += rb.velocity * Time.deltaTime;
        }
        void OnTriggerEnter(Collider col)
        {
            e = col.GetComponent<Enemy>();
            if (e != null)
            {
                e.DealDamage(damage);
                Destroy(col.gameObject);
            }
            if (col.name == "Ground")
            {
                Destroy(this);
            }
        }
    }
}