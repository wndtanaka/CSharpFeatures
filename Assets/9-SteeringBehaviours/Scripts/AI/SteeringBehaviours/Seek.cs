using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;
namespace AI
{
    public class Seek : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance = 1f;

        public override Vector3 GetForce()
        {
            // LET force = Vector3.zero
            force = Vector3.zero;
            // IF target == null
            if (target == null)
            {
                // return force
                return force;
            }
            // LET desiredForce = target.position - transform.position
            Vector3 desiredForce = target.position - transform.position;

            //IF desiredForce.magnitude > stoppingDistance
            if (desiredForce.magnitude > stoppingDistance)
            {
                // SET desiredForce = desiredForce.normalized * weighting
                desiredForce = desiredForce.normalized * weight;
                // SET force = desiredForce - owner.velocity
                force = desiredForce - owner.velocity;
            }
            #region GizmosGL
            GizmosGL.color = Color.red;
            GizmosGL.AddLine(transform.position, transform.position + force);
            GizmosGL.color = Color.blue;
            GizmosGL.AddLine(transform.position, transform.position + desiredForce);
            #endregion
            // Return the force... luke
            return force;
        }
    }
}