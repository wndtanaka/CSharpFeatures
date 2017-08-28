﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Breakout
{
    public class SceneNavigator : MonoBehaviour {

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void BlockDestroyed()
        {
            if (DestroyBlocks.blockCount <= 0) // if last brick is destroyed, load next level
            {
                LoadNextLevel();
            }
        }
    }
}