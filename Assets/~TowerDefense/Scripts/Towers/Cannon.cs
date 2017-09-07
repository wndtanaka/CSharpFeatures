using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cannon : MonoBehaviour
    {
        public Transform barrel; // Reference to barrel where bullet will be shot from
        public GameObject projectilePrefab; // Prefab of projectile to instantiate when firing
       public void Fire(Enemy targetEnemy)
        {
            // LET targetPos = targetEnemy's position
            Vector3 targetPos = targetEnemy.transform.position;
            // LET barrelPos = barrel's position
            Vector3 barrelPos = barrel.position;
            // LET barretRot = barrels rotation
            Quaternion barrelRot = barrel.rotation;
            // LET fireDirection = targetPos - barrelPos
            Vector3 fireDirection = targetPos - barrelPos;
            // SET cannon's rotation = Quaternion.LookRotation(fireDirection,Vector3.up)
            // LET clone = Instantiate(projectilePrefab, barrelPos, barrelRot)
            
            // LET p = clone's Projectile component
            // SET p.direction = fireDirection
        }
    }
}