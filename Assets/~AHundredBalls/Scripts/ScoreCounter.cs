using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public Text scoreText;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            score++;
            Debug.Log(score);
        }
    }
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
