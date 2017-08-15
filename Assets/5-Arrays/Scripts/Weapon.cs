using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{
    public class Weapon : MonoBehaviour
    {
        public int damage;
        public int maxBullets = 30;
        public float fireInterval = 0.2f;
        public GameObject bulletPrefab;
        public Transform SpawnPoint;

        private Transform target;
        public bool isFired = false;
        private int currentBullets = 0;
        private Bullet[] spawnedBullets; // null by default

        // Use this for initialization
        void Start()
        {
            spawnedBullets = new Bullet[maxBullets];
        }

        // Update is called once per frame
        void Update()
        {
            // IF !isFired && currenBullet < maxBullet = fire
            if (!isFired && currentBullets < maxBullets)
            {
                StartCoroutine(Fire());
            }
        }

        IEnumerator Fire()
        {
            isFired = true;
            SpawnBullet();
            yield return new WaitForSeconds(fireInterval); // Wait for fire interval to finish
            // Run whatever is here after the fireInterval
            isFired = false;
        }

        void SpawnBullet()
        {
            //1 Instantiate a  bullet clone
            GameObject clone = Instantiate(bulletPrefab, SpawnPoint.position, Quaternion.identity);
            // 2 Create direction a variable for bullet and rotating
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            // 3 Rotate the weapon to direction
            transform.rotation = Quaternion.LookRotation(direction);
            // 4 Grab the bullet script from clone
            Bullet bullet = clone.GetComponent<Bullet>();
            // 5 Send bullet to target(by Setting direction)
            bullet.direction = direction;
            // 6 Store bullet in array using currentBullets as index
            spawnedBullets[currentBullets] = bullet;
            // 7 Increment currentBullets
            currentBullets++;
        }
        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}