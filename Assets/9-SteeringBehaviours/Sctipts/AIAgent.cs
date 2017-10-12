using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public Vector3 force; // total force calculated from behaviours
        public Vector3 velocity; // direction of travel and speed
        public float maxVelocity = 100f; // max amount of velocity
        public float maxDistance = 10f; // 
        public bool freezeRotation = false;// do we freeze rotation?

        private NavMeshAgent nav;
        // List of SteeringBehaviours (i.e, Seek, Flee, Wander, etc)
        private List<SteeringBehaviour> behaviours;

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        // Use this for initialization
        void Start()
        {
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        void ComputeForces()
        {
            // SET force to zero
            force = Vector3.zero;
            // FOR i = 0 to behaviours count
            for (int i = 0; i < behaviours.Count; i++)
            {
                // LET behaviour = behaviours[i]
                SteeringBehaviour behaviour = behaviours[i];
                // IF behaviour is not enabled
                if (behaviour.isActiveAndEnabled == false)
                {
                    // CONTINUE
                    continue;
                }
                // SET force = force + behaviour.GetForce() * weighting
                force += behaviour.GetForce() * behaviour.weight;
                // IF force > maxVelocity
                if (force.magnitude > maxVelocity)
                {
                    // SET force to force normalized x maxVelocity
                    force = force.normalized * maxVelocity;
                    // BREAK
                    break;
                }
            }

        }

        void ApplyVelocity()
        {
            // SET velocity to velocity + force x deltatime
            velocity += force * Time.deltaTime;
            // IF velocity > maxVelocity
            if (velocity.magnitude > maxVelocity)
            {
                // SET velocity = velocity.normalized x maxVelocity
                velocity = velocity.normalized * maxVelocity;
            }
            // IF velocity > zero
            if (velocity.magnitude > 0)
            {
                //SET position = position + velocity x deltatime
                transform.position += velocity * Time.deltaTime;
                // SET rotation to Quaternion.LookRotation velocity
                transform.rotation = Quaternion.LookRotation(velocity);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ComputeForces();
            ApplyVelocity();
        }
    }
}