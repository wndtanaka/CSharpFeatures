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
        public Transform explosionParticles;

        private Animator anim;
        private EnemyAgent ea;

        void Awake()
        {
            anim = GetComponent<Animator>();
            ea = GetComponent<EnemyAgent>();
        }
        public override void Attack()
        {
            Explode();
        }

        IEnumerator Explode()
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
        }
        
    }
}