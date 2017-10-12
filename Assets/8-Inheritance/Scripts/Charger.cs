using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float impactForce =10f;
        public float knockback = 10f;
        public Transform chargeParticles;

        private Animator anim;
        private EnemyAgent ea;

        void Awake()
        {
            anim = GetComponent<Animator>();
            ea = GetComponent<EnemyAgent>();
        }

        public override void Attack()
        {
            Charge();
        }
        IEnumerator Charge()
        {
            yield return new WaitForSeconds(1.2f);
            Instantiate(chargeParticles,transform.position,transform.rotation);
            Destroy(gameObject, 2f);
        }
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                anim.SetBool("isCharge", true);
                ea.nav.Stop();
                StartCoroutine(Charge());
            }
        }
    }
}