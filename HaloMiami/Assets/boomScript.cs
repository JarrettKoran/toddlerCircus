using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Destroy (gameObject, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter (Collider other){
        if (other.tag == "Player")
            other.transform.GetChild(0).GetChild(0).GetComponent<shootFPS>().HitPlayer(25);
	}
}
