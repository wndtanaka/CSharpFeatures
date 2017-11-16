using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GGL;

namespace MOBA
{
    [RequireComponent(typeof(Camera))]
    public class AIAgentDirector : MonoBehaviour
    {
        public LayerMask hitLayers;
        public float rayDistance = 100f;
        public AIAgent[] agentsToDirect;

        Camera cam;
        Transform selectionPoint;

        void Awake()
        {
            cam = GetComponent<Camera>();
        }
        void Start()
        {
            GameObject g = new GameObject("Target Location");
            selectionPoint = g.transform;
        }
        void AssignTargetToAllAgents(Transform target)
        {
            foreach (AIAgent agent in agentsToDirect)
            {
                Seek s = agent.GetComponent<Seek>();
                if (s != null)
                {
                    s.target = target;
                }
            }
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(camRay, out hit, rayDistance, hitLayers))
                {
                    NavMeshHit navHit;
                    if (NavMesh.SamplePosition(hit.point, out navHit, rayDistance, -1))
                    {
                        selectionPoint.position = navHit.position;
                        AssignTargetToAllAgents(selectionPoint);
                    }
                }
            }
        }
    }
}