using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Breakout
{
    public class ScoreBoard : MonoBehaviour
    {
        private Text scoreBoard;

        // Use this for initialization
        void Start()
        {
            scoreBoard = GetComponent<Text>();

        }

        // Update is called once per frame
        void Update()
        {
            ScoreBoardDisplay(); // calling ScoreBoardDisplay in update when block destroyed
        }
        void ScoreBoardDisplay()
        {
            scoreBoard.text = "Score: " + DestroyBlocks.currentScore; // displaying score (calling var from DestroyBlocks class)
        }
    }
}
