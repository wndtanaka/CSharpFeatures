using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreBoard;
    public int score;

    void Start()
    {
        scoreBoard = FindObjectOfType<Text>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            score++;
            Debug.Log(score);
        }
    }
}
