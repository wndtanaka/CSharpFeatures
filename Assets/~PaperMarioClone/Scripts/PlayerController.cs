using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float walkSpeed = 20f;
        public float runSpeed = 30f;
        public float jumpHeight = 10f;
        public bool moveInJump = false;
        public bool isRunning = false;
        public bool isGrounded
        {
            get { return controller.isGrounded; }
        }

        private CharacterController controller;
        private Vector3 gravity;
        private Vector3 movement;
        private bool jump = false;
        private Vector3 inputDir;
        private Animator anim;

        // Use this for initialization
        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isRunning)
            {
                movement *= runSpeed;
            }
            else
            {
                movement *= walkSpeed;
            }
            if (isGrounded)
            {
                gravity = Vector3.zero;
                if (jump)
                {
                    gravity.y = jumpHeight;
                    jump = false;
                } 
            }
            else
            {
                gravity += Physics.gravity * Time.deltaTime;
            }
            movement += gravity;
            controller.Move(movement * Time.deltaTime);
        }
        public void Jump()
        {
            jump = true;
        }
        public void Move(float inputH, float inputV)
        {
           
            if (moveInJump || (moveInJump == false && isGrounded))
            {
                inputDir = new Vector3(inputH, 0, inputV);
            }
            movement = transform.TransformDirection(inputDir);
        }

    }
}