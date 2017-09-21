using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreBoard;

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
        scoreBoard.text = "Score: " + score;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bucket")
        {
            score++;
            Debug.Log(score);
        }
    }
}
