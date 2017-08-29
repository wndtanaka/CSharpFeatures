using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Paddle : MonoBehaviour
    {
        public float movementSpeed = 50f; // speed the paddle moves
        public Ball currentBall; // ball that should be attached to the paddle as a child
        public Vector2[] directions = new Vector2[]
            {
                new Vector2(-0.5f,0.5f),
                new Vector2(0.5f,0.5f)
            }; // list of directions for the ball to choose from
        public bool isLaunch = true;


        // Use this for initialization
        void Start()
        {
            // grab currentBall from children of the paddle
            currentBall = GetComponentInChildren<Ball>();
        }

        // Update is called once per frame
        void Update()
        {
            CheckInput();
            Movement();
        }
        void Fire()
        {
            // detach as a child
            currentBall.transform.SetParent(null);
            // generate random dir from list of directions
            Vector3 randomDir = directions[Random.Range(0, directions.Length)];
            // fire off ball in direction
            currentBall.Fire(randomDir);
        }
        void CheckInput()
        {
            if (isLaunch)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Fire();
                    isLaunch = false; // change isLaunch to false, so it will not activate for more than once.
                }
            }
        }
        void Movement()
        {
            // get input from horizontal axis
            float inputH = Input.GetAxis("Horizontal");
            // set force to direction (inputH to decide which direction)
            Vector3 force = transform.right * inputH;
            // apply movement speed to force
            force *= movementSpeed;
            // apply deltatime to force
            force *= Time.deltaTime;
            // add force to position
            transform.position += force;

        }
    }
}