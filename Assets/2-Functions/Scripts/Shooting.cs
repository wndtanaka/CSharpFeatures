using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions
{
    public class Shooting : MonoBehaviour
    {
        // Stores the object we want to Instantiate
        public GameObject projectilePrefab;
        // Kickback from firing a projectile
        public float recoil = 5;
        // Speed at which the projectile will flung
        public float projectileSpeed = 20f;
        // Rate of fire
        public float shootRate = 0.1f;
        // Timer to count shootRate
        private float shootTimer = 0f;
        // Container for Rigidbody2D
        private Rigidbody2D rigid;

        void Start()
        {
            // Get component from GameObject this game attached to
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Increase timer
            shootTimer += Time.deltaTime;
            // If spacebar is pressed AND shootTImer >= shootRate
            // CALL Shoot()
            // RESET shootTimer = 0
            if (Input.GetKey(KeyCode.Space) && shootTimer >= shootRate)
            {
                Shoot();
                shootTimer = 0;
            }
        }
        void Shoot()
        {
            // Instantiate GameObject here
            GameObject projectile = Instantiate(projectilePrefab);
            // Projectile Position = Player Position
            projectile.transform.position = transform.position;


            Rigidbody2D rigid2D = projectile.GetComponent<Rigidbody2D>();
            // rigid2D.AddForce(transform.right * projectileSpeed);
            // Add velocity to the bullet
            rigid2D.velocity = transform.right * projectileSpeed;
            // Apply a recoil
            rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
            // Destroy the bullet after 1 seconds
            // Destroy(projectile, 1.0f);
        }
    }
}
