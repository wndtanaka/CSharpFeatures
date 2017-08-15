using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public Vector2 spacing = new Vector2(25f, 10f);
        public Vector2 offset = new Vector2(-25f, 0f);
        public GameObject[] blockPrefabs;
        [Header("Debug")]
        public bool isDebugging = false;

        private GameObject[,] spawnedBlocks;
        // Use this for initialization
        void Start()
        {
            GenerateBlocks();
        }

        GameObject GetBlockByIndex(int index)
        {
            if (index > blockPrefabs.Length || index < 0)
            {
                return null;
            }
            GameObject clone = Instantiate(blockPrefabs[index]);
            return clone;
        }
        GameObject GetRandomBlocks()
        {
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject randomPrefab = blockPrefabs[randomIndex];
            GameObject clone = Instantiate(randomPrefab);
            return clone;
        }

        void GenerateBlocks()
        {
            spawnedBlocks = new GameObject[width, height];
            // Loop Through the width
            for (int x = 0; x < width; x++)
            {
                // Loop Through the height
                for (int y = 0; y < height; y++)
                {

                    GameObject block = GetRandomBlocks();
                    // Set a new position

                    Vector2 pos = new Vector2(x * spacing.x, y * spacing.y);
                    block.transform.position = pos;
                    spawnedBlocks[x, y] = block;
                }
            }
        }
        void UpdateBlocks()
        {
            // Loop through entire 2d array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Update positions
                    GameObject currentBlocks = spawnedBlocks[x, y];
                    // Create a new position
                    Vector2 pos = new Vector2(x * spacing.x, y * spacing.y);
                    // Add and offset to pos
                    pos += offset;
                    // Set currentBlocks position to new pos
                    currentBlocks.transform.position = pos;
                }
            }

        }
        // Update is called once per frame
        void Update()
        {
            if (isDebugging)
            {
                UpdateBlocks();
            }
        }
    }
}