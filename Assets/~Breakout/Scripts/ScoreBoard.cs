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
            ScoreBoardDisplay();
        }
        void ScoreBoardDisplay()
        {
            scoreBoard.text = "Score: " + DestroyBlocks.currentScore;
        }
    }
}
