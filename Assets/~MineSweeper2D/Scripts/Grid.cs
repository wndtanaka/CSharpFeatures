using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MineSweeper2D
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public static int width = 10;
        public static int height = 10;
        public float spacing = 0.155f;

        private float offset = 0.5f;
        public static Tile[,] tiles = new Tile[width, height];
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // Use this for initialization
        void Start()
        {
            // Generate tiles on startup
            GenerateTiles();
        }

        // Update is called once per frame
        void Update()
        {
            OnMouseDown();
        }
        // functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // position tile
            Tile currentTile = clone.GetComponent<Tile>(); // get tile component
            return currentTile; // return it
        }
        // spawn tiles in a grid-like pattern
        void GenerateTiles()
        {
            // create new 2D array of size width * height
            //tiles = new Tile[width, height];

            // loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);
                    // Pivot tiles around grid
                    Vector2 pos = new Vector2((x + offset) - halfSize.x, (y + offset) - halfSize.y); // applying offset to make it centre
                    // apply spacing
                    pos *= spacing;
                    // spawn the tile
                    Tile tile = SpawnTile(pos);
                    // attach newly spawn tile to
                    tile.transform.SetParent(transform);
                    // store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    // store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }
        }
        public int GetAdjacentMineCountAt(Tile t)
        {
            int count = 0;
            // loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x < 1; x++)
            {
                // calculate desired coordinates from ones attained
                for (int y = -1; y < 1; y++)
                {
                    int desiredX = t.x + x;
                    int desiredY = t.y + y;
                    if ((desiredX >= x || desiredX <= x) && (desiredY >= y || desiredY <= y))
                    {

                    }
                }
            }
            return count;
        }
        void OnMouseDown()
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint,mousePosition);

            //    if (hit != null && hit.collider != null)
            //    {
            //        isHit = false;
            //        Destroy(GameObject.Find(hit.collider.gameObject.name));
            //    }
            //}
        }
        //public static void uncoverMines()
        //{
        //    foreach (Tile tile in tiles)
        //    {
        //        if (tile.isMine)
        //        {
        //            tile.
        //        }
        //    }
        //}
    }
}