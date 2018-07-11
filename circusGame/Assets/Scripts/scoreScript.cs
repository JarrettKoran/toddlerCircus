using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

    public GameObject scoreUI;

    public Text scoreText;
    public Text livesText;

    private int score;
    private int lives;

    // Use this for initialization
    void Start () {
        lives = 3;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("player").GetComponent<worldScript>().playerLives != lives)
        {
            lives = GameObject.Find("player").GetComponent<worldScript>().playerLives;
            livesText.text = "" + lives.ToString();
        }
        if (GameObject.Find("player").GetComponent<worldScript>().playerPoints != score)
        {
            score = GameObject.Find("player").GetComponent<worldScript>().playerPoints;
            scoreText.text = "" + score.ToString();
        }
    }
}
