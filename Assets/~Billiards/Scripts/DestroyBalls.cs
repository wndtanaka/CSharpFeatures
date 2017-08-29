using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class DestroyBalls : MonoBehaviour
    {
        public static int currentScore;

        private bool isBallIn = true;
        public AudioSource audio;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        void OnTriggerEnter(Collider col)
        {
            if (isBallIn)
            {
                audio.Play();
                Destroy(col.gameObject);
                currentScore++;
            }
            print("Score: " + currentScore);
        }
    }
}