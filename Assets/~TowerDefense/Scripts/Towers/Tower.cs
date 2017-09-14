﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public Cannon cannon; // Reference to cannon inside of tower
        public float attackRate = 0.25f; // Rate of attack in seconds
        public float attackRadius = 5f; // Distance of attack in world units
        private float attackTimer = 0f; // Timer to count up to attackRate
        private List<Enemy> enemies = new List<Enemy>(); // List of enemies within radius

        void OnTriggerEnter(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if(e!= null)
            {
                enemies.Add(e);
            }
        }
        void OnTriggerExit(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {
                enemies.Remove(e);
            }
        }
        Enemy GetClosestEnemy()
        {
            enemies = RemoveAllNulls(enemies);

            Enemy closest = null;
            float minDistance = float.MaxValue;
            foreach (Enemy enemy in enemies)
            {
                float distance = Vector3.Distance(cannon.transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = enemy;
                }
            }
            return closest;
        }
        void Attack()
        {
            Enemy closest =  GetClosestEnemy();
            if(closest!= null)
            {
                cannon.Fire(closest);
            }
        }
        void Update()
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0;
            }
        }
        List<Enemy> RemoveAllNulls(List<Enemy> listWithNulls)
        {

            List<Enemy> listWithoutNulls = new List<Enemy>();
            // Loop through listWithNulls
            for (int i = 0; i < listWithNulls.Count; i++)
            {
                // Check if element is NOT null
                if (listWithNulls[i] != null)
                {
                    // Add element to listWithoutNulls
                    listWithoutNulls.Add(listWithNulls[i]);
                }
            }
            return listWithoutNulls;
        }
    }
}