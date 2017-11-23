using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    [RequireComponent(typeof(PathFollowing))]
    public class Patrol : MonoBehaviour
    {
        public AIAgentPatrolSelector patrolSelector;

        private int currentPoint = 0; // the curremt patrol points the gaent is PathFollowing to
        private PathFollowing pathFollowing; // Reference to the attached PathFollowing script
        private List<Transform> patrolPoints; // List of patrol point (referring to the one int the patrolSelector)
        // Use this for initialization
        void Start()
        {
            pathFollowing = GetComponent<PathFollowing>();
        }

        // Update is called once per frame
        void Update()
        {
            // is there currently a patrol selector?
            if (patrolSelector != null)
            {
                // grab patorl points list from selector
                patrolPoints = patrolSelector.patrolPoints;
                // is there any patrol point added from the selector?
                if (patrolPoints.Count > 0)
                {
                    // is the agent at the target?
                    if (pathFollowing.isAtTarget)
                    {
                        // reset the currentNode the agent seeks to
                        pathFollowing.currentNode = 0;
                        // move to the next patrol point
                        currentPoint++;
                    }
                    // Is currentPoint outside of list count?
                    if (currentPoint >= patrolPoints.Count)
                    {
                        currentPoint = 0;
                    }
                    Transform point = patrolPoints[currentPoint];
                    pathFollowing.target = point; 
                }
            }
        }
    }
}