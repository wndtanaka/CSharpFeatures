using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public Text scoreBoard;
    ScoreCounter scoreCounter;

    // Use this for initialization
    void Awake()
    {
        scoreBoard = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();
    }
    void DisplayScore()
    {
        scoreBoard.text = "Score: " + scoreCounter.score;
    }
}
