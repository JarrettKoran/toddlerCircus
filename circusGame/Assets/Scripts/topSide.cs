using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topSide : MonoBehaviour {

	public Object player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
  {

  }
	void OnTriggerExit2D(Collider2D other)
  {
    	if(other.tag != "Player") {
				GameObject.Find("player").GetComponent<worldScript>().playerLives--;
				Destroy(other.gameObject);
			}
  }

}
