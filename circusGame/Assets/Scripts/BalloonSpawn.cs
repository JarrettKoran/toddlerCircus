﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour {

	 public float nextActionTime = 0.0f;
    public float period = 5.0f;   

	 public Object greenBalloon;
	 public Object redBalloon;
	 public Object yellowBalloon;
     public Object blueBalloon;
     public Object whiteBalloon;
     public Object specialBalloon;

     private bool green;
	 private bool red;
	 private bool yellow;
     private bool blue;
     private bool white;
     private bool specc;

    public bool playmode = true;
    public bool firsttime = false;

	 public int currLevel = 1;
	 public int balloonsLeft = 10;
	 public int balloonsPopped = 0;

	public float timer;

	// Use this for initialization
	void Start () {

        specc = false;

        currLevel = 1;

		green = false;
	 	red = false;
	 	yellow = false;
        blue = false;
        white = false;
        int random = Random.Range(0,5);
		if(random == 0) {
			green = true;
			Debug.Log("Look at Green Balloons");
		} else if (random == 1) {
			red = true;
			Debug.Log("Look at Red Balloons");
		} else if (random == 2) {
			yellow = true;
			Debug.Log("Look at Yellow Balloons");
		} else if (random == 3) {
            blue = true;
            Debug.Log("Look at Blue Balloons");
        } else {
            white = true;
            Debug.Log("Look at White Balloons");
        }


		timer = 0f;
    }

	// Update is called once per frame
	void Update () {

        if (balloonsPopped == balloonsLeft && firsttime)
        {
            currLevel++;
            Debug.Log("Level " + currLevel);
            balloonsPopped = 0;
			nextActionTime -= .5f;
            firsttime = false;
        }

        int specially = 0;

		if (nextActionTime <= 2.5f )
			nextActionTime = 2.5f;

        if (Time.timeScale == 1.0f)
        {
			timer += Time.deltaTime;
            if (timer > nextActionTime)
            {
				timer = 0;
                specially++;
                if(specially == 3)
                {
                    specc = true;
                    specially = 0;
                    Debug.Log("yeet");
                }
                if (currLevel < 11)
                {
                    if(specc)
                    {
                        Instantiate(specialBalloon, new Vector3(Random.Range(-9f, 2.75f),
                            this.transform.position.y, this.transform.position.z), Quaternion.identity);
                            specc = false;
                    }
                    else if (green)
                    {
                        Instantiate(greenBalloon, new Vector3(Random.Range(-9f, 2.75f),
                                this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    }
                    else if (red)
                    {
                        Instantiate(redBalloon, new Vector3(Random.Range(-9f, 2.75f),
                                this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    }
                    else if (blue)
                    {
                        Instantiate(blueBalloon, new Vector3(Random.Range(-9f, 2.75f),
                                this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    }
                    else if (white)
                    {
                        Instantiate(whiteBalloon, new Vector3(Random.Range(-9f, 2.75f),
                                this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    }
                    else if (yellow)
                    {
                        Instantiate(yellowBalloon, new Vector3(Random.Range(-9f, 2.75f),
                                this.transform.position.y, this.transform.position.z), Quaternion.identity);
                    }
                }
            }
        }


	}
}
