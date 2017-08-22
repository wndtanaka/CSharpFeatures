using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class DestroyBlocks : MonoBehaviour
    {
        public static int currentScore;       
        void OnCollisionEnter2D(Collision2D col)
        {
            if (this.gameObject.tag == "Blocks")
            {
                currentScore += 1;
                // Destroy(gameObject); // This will destroy the object but errors will show up
                this.gameObject.SetActive(false); // this is a hacky way
            }
            print("Score " + currentScore);
        }
    }
}
