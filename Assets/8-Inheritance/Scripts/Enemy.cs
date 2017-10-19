using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy")]
        public Transform target;
        public int health = 100;
        public int damage = 20;
        public float attackDuration = 2f;
        public float attackRate = 5f;
        public float attackRadius = 10f;

        protected NavMeshAgent nav;
        protected Rigidbody rb;

        private float attackTimer = 0f;

        protected virtual void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rb = GetComponent<Rigidbody>();
        }
        protected virtual void Update()
        {
            if (target == null)
            {
                return;
            }
            nav.SetDestination(target.position);

            attackTimer += Time.deltaTime;
            if(attackTimer>= attackRate)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance <= attackRadius)
                {
                    Attack();
                    attackTimer = 0f;
                    StartCoroutine(AttackDelay(attackDuration));
                }
            }
        }

        protected virtual void Attack()
        {

        }
        protected virtual void OnAttackEnd()
        {

        }
        IEnumerator AttackDelay(float delay)
        {
            nav.Stop();
            yield return new WaitForSeconds(delay);
            nav.Resume();
            OnAttackEnd();
        }
    }
}