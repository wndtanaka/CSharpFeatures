using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;
        public float shootRate = 0.2f;

        private float shootTimer = 0f;

        void Shoot()
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation); // instantiate bullet
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>(); // get bullet(clone)'s rigidbody component
            rigid.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse); // adding force, impulse mode for instant shoot?
        }
        void Update()
        {
            shootTimer += Time.deltaTime; // adding shootTimer with delta time, in order to compare it with shootRate 
            if (shootTimer > shootRate)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Shoot();
                    shootTimer = 0; // reset shoot timer so, it will count again from zero until shootTimer > shootRate
                }
            }
        }
    }
}