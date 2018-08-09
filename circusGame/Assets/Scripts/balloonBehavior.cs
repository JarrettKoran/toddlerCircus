﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonBehavior : MonoBehaviour
{

    public Object pop;
    //Used for determining how long it takes to orient to balloon
    public float timeBalloonSpawned;
    public bool balloonShrunk;
    public float timeToFindBalloon;
    public DataLogger data;

    public bool moving;
    public bool special;

    // Use this for initialization
    void Start()
    {
        timeBalloonSpawned = Time.time;
        balloonShrunk = false;
        timeToFindBalloon = 0.0f;

        moving = true;
        special = false;

        GameObject go = GameObject.Find("DataManager");
        //Logger logger = go.GetComponent<Logger>();
        //data = logger.GetLogger();
        data = go.GetComponent<DataLogger>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Time.timeScale == 1.0f && moving)
            this.transform.Translate(0, .03f, 0);
        //time it takes to find balloon
        if (this.transform.localScale.x < 1 && balloonShrunk == false)
        {
            timeToFindBalloon = Time.time - timeBalloonSpawned;
            balloonShrunk = true;
            data.LogEntry("Time To Orient", timeToFindBalloon);
            /*
            for (int i = 0; i < data.totalData["TimeToOrient"].Count; i++)
            {
                Debug.Log("Data point " + i + ": " + data.totalData["TimeToOrient"][i]);
            }
            */

        }

        if (this.transform.localScale.x <= .3f)
        {
            float poppedTime = Time.time - timeBalloonSpawned;
            if (poppedTime <= 4.2)
            {
                GameObject.Find("player").GetComponent<worldScript>().playerPoints += 3;
            }
            else if (poppedTime <= 5.5)
            {
                GameObject.Find("player").GetComponent<worldScript>().playerPoints += 2;
            }
            else
            {
                GameObject.Find("player").GetComponent<worldScript>().playerPoints++;
            }
            GameObject.Find("balloonSpawn").GetComponent<BalloonSpawn>().balloonsPopped++;
            GameObject.Find("balloonSpawn").GetComponent<BalloonSpawn>().firsttime = true;
            Instantiate(pop, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(this.transform.localScale.x <= .02f && special == true)
        {
            Debug.Log("yeet");
            GameObject.Find("player").GetComponent<worldScript>().playerPoints += 5;
            GameObject.Find("balloonSpawn").GetComponent<BalloonSpawn>().balloonsPopped++;
            GameObject.Find("balloonSpawn").GetComponent<BalloonSpawn>().firsttime = true;
            Instantiate(pop, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        

      if (GameObject.Find("ButtonManager").GetComponent<buttonManager>().gameOver == true)
        {
            Destroy(this.gameObject);
        }
    }
}
