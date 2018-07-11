﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using System.Threading;

public class crosshairScript : MonoBehaviour {


	public int playerLives = 3;
    public int count = 0;
	public float balloonExitTime;
    public Dictionary<Collider2D, float> collidingObjects;
    public DataLogger data;

	// Use this for initialization
	void Start () {
        collidingObjects = new Dictionary<Collider2D, float>();
		balloonExitTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        //Vector3 screenPoint = TobiiAPI.GetGazePoint().Screen;
        //screenPoint.z = 1f;
        //this.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        // if(!GameObject.Find("PauseMenu").GetComponent<pauseMenu>().gamePaused) 
        // {
        Vector3 temp = Input.mousePosition;
        temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        // }
    }

	void OnTriggerEnter2D(Collider2D other){
        //Set time the balloon was first looked at and add it to our collidingObjects Dictionary
        float timeOfEntry = Time.time;
        collidingObjects.Add(other, timeOfEntry);
        count++;

        //Log how long its been since last contact has been from last balloon
        data.LogEntry("Time Between Balloons", (Time.time - balloonExitTime));
        //Debug.Log("Count is: " + count);

	}
	void OnTriggerStay2D(Collider2D other){
        //Decrease size of object (balloon) while looked at
        if (other.transform.localScale.x >.1 && other.tag != "Respawn")
        {
            other.transform.localScale -= new Vector3(.007f, .007f, 0);
        }
        //Debug.Log("This is happening " + collidingObjects[other]);

	}
	void OnTriggerExit2D(Collider2D other){
        //Collect how long an object was looked at, log the data, then remove object from dictionary to clear space.
        collidingObjects[other] = (Time.time - collidingObjects[other]);
        //Debug.Log("Final fixation time: " + collidingObjects[other]);
        data.LogEntry("Fixation Time", collidingObjects[other]);
        //Debug.Log("Fixation Time was: " + data.totalData["Fixation Time"][data.totalData["Fixation Time"].Count - 1]);
        collidingObjects.Remove(other);
        //Set the exit time
        balloonExitTime = Time.time;
	}
}
