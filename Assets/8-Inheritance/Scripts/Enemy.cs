using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [Header("Base Enemy")]
        public Transform target;
        public float damage = 50f;
        public float attackDuration = 2f;
        public float attackRange = 2f;

        protected NavMeshAgent nav;
        protected Rigidbody rigid;

        private float attackTimer = 0f;

        // Use this for initialization
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        protected virtual void Attack()
        {
            
        }
        protected virtual void OnAttackEnd()
        {

        }

        IEnumerator AttackDelay(float delay)
        {
            // I'm gonna to have a bunch of statements
            // ... and I want them run immediately
            nav.Stop();
            yield return new WaitForSeconds(delay);
            // Do this stuff after delay
            nav.Resume();
            OnAttackEnd();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            // Update the nav destination
            nav.SetDestination(target.position);
            // Increase the attack timer
            attackTimer += Time.deltaTime;
            // CHeck if attack is ready
            if(attackTimer >= attackDuration)
            {
                // Check distance to target
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance <= attackRange)
                {
                    StartCoroutine(AttackDelay(attackDuration));
                    Attack();
                    attackTimer = 0f;
                }
            }
        }
    }
}