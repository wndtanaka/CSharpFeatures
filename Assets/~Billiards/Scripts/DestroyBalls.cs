using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class DestroyBalls : MonoBehaviour
    {
        public static int currentScore;

        private bool isBallIn = true;

        void OnTriggerEnter(Collider col)
        {
            if (isBallIn)
            {
                Destroy(gameObject);
                currentScore++;
            }
            print("Score: " + currentScore);
        }
    }
}