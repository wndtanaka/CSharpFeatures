using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    // Forces unity to add 'Controller2D' Component to the same object as 'UserInput2D' as soon as ypu attach this script to a GameObject
    [RequireComponent(typeof(Controller2D))]
    public class UserInput2D : MonoBehaviour
    {
        private Controller2D controller;
        // Use this for initialization
        void Awake()
        {
            controller = GetComponent<Controller2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float inputH = Input.GetAxis("Horizontal");
            controller.Move(inputH);

            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            {
                controller.Jump();
            }
        }
    }
}