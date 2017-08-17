using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collisions
{
    public class MuzzleFlash : MonoBehaviour
    {
        public int maxFrames = 1;
        private int currentFrames = 0;
        // Update is called once per frame
        void Update()
        {
            if (currentFrames >= maxFrames)
            {
                Destroy(gameObject);
            }
            currentFrames++;
        }
    }
}