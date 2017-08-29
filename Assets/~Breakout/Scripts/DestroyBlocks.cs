using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class DestroyBlocks : MonoBehaviour
    {
        public static int blockCount = 0;
        public int maxHit;
        public static int currentScore;
        private int currentHit = 0;
        private SceneNavigator scene;

        void Start()
        {
            blockCount++; // increase block count
            scene = GameObject.FindObjectOfType<SceneNavigator>();
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (gameObject)
            { // seperate each block by tag
                if (gameObject.tag == "1Hit") // checking block by tag
                {
                    currentHit++;
                    if (currentHit >= maxHit)
                    {
                        blockCount--; // decrease block count when it destroy
                        scene.BlockDestroyed(); // calling BlockDestroyed function from SceneNavigator
                        //Destroy(gameObject); // This will destroy the object but errors will show up
                        this.gameObject.SetActive(false); // this is a hacky way
                        currentScore += 1; // adding score upon breaking this block
                    }
                }
                if (gameObject.tag == "2Hit") // checking block by tag
                {
                    currentHit++;
                    if (currentHit >= maxHit)
                    {
                        blockCount--; // decrease block count when it destroy
                        scene.BlockDestroyed(); // calling BlockDestroyed function from SceneNavigator
                        //Destroy(gameObject); // This will destroy the object but errors will show up
                        this.gameObject.SetActive(false); // this is a hacky way
                        currentScore += 2; // adding score upon breaking this block
                    }
                }
                if (gameObject.tag == "3Hit") // checking block by tag
                {
                    currentHit++;
                    if (currentHit >= maxHit)
                    {
                        blockCount--; // decrease block count when it destroy
                        scene.BlockDestroyed(); // calling BlockDestroyed function from SceneNavigator
                        //Destroy(gameObject); // This will destroy the object but errors will show up
                        this.gameObject.SetActive(false); // this is a hacky way
                        currentScore += 3; // adding score upon breaking this block
                    }
                }
                print("Score " + currentScore); // print current score
            }     
        }
    }
}
