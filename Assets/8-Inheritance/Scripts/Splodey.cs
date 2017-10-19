using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float explosionRadius = 10f;
        public float impactForce = 10f;
        public float explosionRate = 1f;
        public Transform explosionParticles;

        private float explosionTimer = 0f;
        //private Animator anim;
        //private EnemyAgent ea;

        protected override void Awake()
        {
            base.Awake();
            //anim = GetComponent<Animator>();
            //ea = GetComponent<EnemyAgent>();
        }
        protected override void Attack()
        {
            explosionTimer += Time.deltaTime;
            if (explosionTimer >= explosionRate)
            {
                Splode();
            }
        }
        protected override void OnAttackEnd()
        {
            explosionTimer = 0f;
        }
        public void Splode()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider hit in hits)
            {
                Health h = hit.GetComponent<Health>();
                if (h != null)
                {
                    h.TakeDamage(damage);
                    rb.AddExplosionForce(impactForce,transform.position,explosionRadius);
                }
            }
        }
        protected override void Update()
        {
            base.Update();
        }
        /*IEnumerator Explode()
        {
            yield return new WaitForSeconds(1f);
            Instantiate(explosionParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                anim.SetBool("isExplode", true);
                StartCoroutine(Explode());
                ea.nav.Stop();
            }
        }*/

    }
}