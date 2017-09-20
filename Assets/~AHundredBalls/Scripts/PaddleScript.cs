using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); // Get athe animator component
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Modify parameter we created earlier
            anim.SetBool("isOpened", true);
        }
        else // If the button isn't pressed
        {
            // Set that parameter to false
            anim.SetBool("isOpened", false);
        }
    }
}
