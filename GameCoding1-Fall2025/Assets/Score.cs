using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = "Score: ";
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddScore(1);
        }
    }

    void AddScore(int amt)
    {
        score += amt;
        scoreText.text = "Score: " + score.ToString();
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(("Player")))
        {
            AddScore(1);
            scoreText.text = "Score: " + score.ToString();
            //Destroy(gameObject);
            Debug.Log(score);
        }
    }*/
}
