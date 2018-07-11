using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldScript : MonoBehaviour {

    public int playerLives = 3;
    public int playerPoints = 0;
    public DataLogger data;


    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (playerLives <= 0)
        {
            GameObject.Find("ButtonManager").GetComponent<buttonManager>().gameOver = true;
            data.LogEntry("GameTime", Time.time);
        }
        

        bool over = GameObject.Find("ButtonManager").GetComponent<buttonManager>().gameOver;
        //bool paused = GameObject.Find("PauseMenu").GetComponent<pauseMenu>().gamePaused;

        if (over == false)
        {
            Cursor.visible = false;
        } else
        {
            Cursor.visible = true;
        }
    }

    
       
}
