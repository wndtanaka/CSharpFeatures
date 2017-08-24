using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class GameManager : MonoBehaviour
    {
        public Ball[] ball;

        private Rigidbody rb;
        public Cue cue;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (rb.IsSleeping())
            {
                cue.Activate();
            }
        }
    }
}