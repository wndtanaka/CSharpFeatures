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

        protected override void Awake()
        {
            base.Awake();

            anim = GetComponent<Animator>();
            ea = GetComponent<EnemyAgent>();
        }

        protected override void Attack()
        {
            
        }
        public void Charge()
        {

        }
        protected override void Update()
        {
            base.Update();
        }
        /*IEnumerator Charge()
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
        }*/
    }
}